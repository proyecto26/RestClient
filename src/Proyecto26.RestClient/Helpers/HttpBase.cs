using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Proyecto26.Common;
using Proto.Promises;

namespace Proyecto26
{
    public static class HttpBase
    {
        private const int HTTP_NO_CONTENT = 204;

        public static IEnumerator CreateRequestAndRetry(RequestHelper options, Action<RequestException, ResponseHelper> callback)
        {

            var retries = 0;
            do
            {
                using (var request = CreateRequest(options))
                {
                    bool IsNetworkError;
#if UNITY_2020_2_OR_NEWER
                    IsNetworkError = (request.result == UnityWebRequest.Result.ConnectionError);
#else
                    IsNetworkError = request.isNetworkError;
#endif
                    var sendRequest = request.SendWebRequestWithOptions(options);
                    if (options.ProgressCallback == null)
                    {
                        yield return sendRequest;
                    }
                    else
                    {
                        options.ProgressCallback(0);

                        while (!sendRequest.isDone)
                        {
                            options.ProgressCallback(sendRequest.progress);
                            yield return null;
                        }

                        options.ProgressCallback(1);
                    }
                    var response = request.CreateWebResponse();
                    if (request.IsValidRequest(options))
                    {
                        DebugLog(options.EnableDebug, string.Format("RestClient - Response\nUrl: {0}\nMethod: {1}\nStatus: {2}\nResponse: {3}", options.Uri, options.Method, request.responseCode, options.ParseResponseBody ? response.Text : "body not parsed"), false);
                        callback(null, response);
                        break;
                    }
                    else if (!options.IsAborted && retries < options.Retries && (!options.RetryCallbackOnlyOnNetworkErrors || IsNetworkError))
                    {
                        if (options.RetryCallback != null)
                        {
                            options.RetryCallback(CreateException(options, request), retries);
                        }
                        yield return new WaitForSeconds(options.RetrySecondsDelay);
                        retries++;
                        DebugLog(options.EnableDebug, string.Format("RestClient - Retry Request\nUrl: {0}\nMethod: {1}", options.Uri, options.Method), false);
                    }
                    else
                    {
                        var err = CreateException(options, request);
                        DebugLog(options.EnableDebug, err, true);
                        callback(err, response);
                        break;
                    }
                }
            }
            while (retries <= options.Retries);
        }

        public static Promise<ResponseHelper> CreateRequestAndRetryAsync(RequestHelper options, CancelationToken cancelationToken = default(CancelationToken))
        {
            var deferred = Promise.NewDeferred<ResponseHelper>();
            RequestAndRetry(deferred, options, cancelationToken.GetRetainer());
            return options.ProgressCallback == null
                ? deferred.Promise
                : deferred.Promise.Progress(options.ProgressCallback);
        }

        // async/await would be cleaner, but it's not available in old .Net 3.5 runtime.
        private static void RequestAndRetry(Promise<ResponseHelper>.Deferred deferred, RequestHelper opts, CancelationToken.Retainer cancelationRetainer, int currentRetryCount = 0)
        {
            var webRequest = CreateRequest(opts);
            PromiseYielder.WaitForAsyncOperation(webRequest.SendWebRequestWithOptions(opts))
                .ToPromise(cancelationRetainer.token)
                .Progress(deferred, (def, progress) => def.ReportProgress(progress))
                .Then(ValueTuple.Create(deferred, opts, currentRetryCount, webRequest, cancelationRetainer), tuple =>
                {
                    var def = tuple.Item1;
                    var options = tuple.Item2;
                    var retries = tuple.Item3;
                    var request = tuple.Item4;
                    var retainer = tuple.Item5;

#if UNITY_2020_2_OR_NEWER
                    bool isNetworkError = (request.result == UnityWebRequest.Result.ConnectionError);
#else
                    bool isNetworkError = request.isNetworkError;
#endif
                    var response = request.CreateWebResponse();
                    if (request.IsValidRequest(options))
                    {
                        DebugLog(options.EnableDebug, string.Format("RestClient - Response\nUrl: {0}\nMethod: {1}\nStatus: {2}\nResponse: {3}", options.Uri, options.Method, request.responseCode, options.ParseResponseBody ? response.Text : "body not parsed"), false);
                        retainer.Dispose();
                        def.Resolve(response);
                    }
                    else if (!options.IsAborted && retries < options.Retries && (!options.RetryCallbackOnlyOnNetworkErrors || isNetworkError))
                    {
                        if (options.RetryCallback != null)
                        {
                            options.RetryCallback(CreateException(options, request), retries);
                        }
                        PromiseYielder.WaitForRealTime(TimeSpan.FromSeconds(options.RetrySecondsDelay))
                            .ToPromise()
                            .Then(tuple, tup =>
                            {
                                DebugLog(tup.Item2.EnableDebug, string.Format("RestClient - Retry Request\nUrl: {0}\nMethod: {1}", tup.Item2.Uri, tup.Item2.Method), false);
                                RequestAndRetry(tup.Item1, tup.Item2, tup.Item5, tup.Item3 + 1);
                            })
                            .Forget();
                    }
                    else
                    {
                        var err = CreateException(options, request);
                        DebugLog(options.EnableDebug, err, true);
                        retainer.Dispose();
                        def.Reject(err);
                    }
                })
                .Finally(webRequest, request => request.Dispose())
                .Forget();
        }

        private static UnityWebRequest CreateRequest(RequestHelper options)
        {
            var url = options.Uri.BuildUrl(options.Params);
            DebugLog(options.EnableDebug, string.Format("RestClient - Request\nUrl: {0}", url), false);
            if (options.FormData is WWWForm && options.Method == UnityWebRequest.kHttpVerbPOST)
            {
                return UnityWebRequest.Post(url, options.FormData);
            }
            else
            {
                return new UnityWebRequest(url, options.Method);
            }
        }

        private static RequestException CreateException(RequestHelper options, UnityWebRequest request)
        {
            bool IsNetworkError;
            bool IsHttpError;
#if UNITY_2020_2_OR_NEWER
            IsNetworkError = (request.result == UnityWebRequest.Result.ConnectionError);
            IsHttpError = (request.result == UnityWebRequest.Result.ProtocolError);
#else
            IsNetworkError = request.isNetworkError;
            IsHttpError = request.isHttpError;
#endif
            return new RequestException(options, request.error, IsHttpError, IsNetworkError, request.responseCode, options.ParseResponseBody ? request.downloadHandler.text : "body not parsed");
        }

        public static void DebugLog(bool debugEnabled, object message, bool isError)
        {
            if (debugEnabled)
            {
                if (isError)
                    Debug.LogError(message);
                else
                    Debug.Log(message);
            }
        }

        public static IEnumerator DefaultUnityWebRequest(RequestHelper options, Action<RequestException, ResponseHelper> callback)
        {
            return CreateRequestAndRetry(options, callback);
        }

        public static IEnumerator DefaultUnityWebRequest<TResponse>(RequestHelper options, Action<RequestException, ResponseHelper, TResponse> callback)
        {
            return CreateRequestAndRetry(options, (RequestException err, ResponseHelper res) => {
                var body = default(TResponse);
                try
                {
                    if (err == null && res.StatusCode != HTTP_NO_CONTENT && res.Data != null && options.ParseResponseBody)
                        body = JsonUtility.FromJson<TResponse>(res.Text);
                }
                catch (Exception error)
                {
                    DebugLog(options.EnableDebug, string.Format("RestClient - Invalid JSON format\nError: {0}", error.Message), true);
                    err = new RequestException(error.Message);
                }
                finally
                {
                    callback(err, res, body);
                }
            });
        }

        public static Promise<TResponse> DefaultUnityWebRequestAsync<TResponse>(RequestHelper options, CancelationToken cancelationToken = default(CancelationToken))
        {
            return CreateRequestAndRetryAsync(options, cancelationToken)
                .Then(res =>
                {
                    try
                    {
                        if (res.StatusCode != HTTP_NO_CONTENT && res.Data != null && options.ParseResponseBody)
                        {
                            return JsonUtility.FromJson<TResponse>(res.Text);
                        }
                        return default(TResponse);
                    }
                    catch (Exception error)
                    {
                        DebugLog(options.EnableDebug, string.Format("RestClient - Invalid JSON format\nError: {0}", error.Message), true);
                        throw new RequestException(error.Message);
                    }
                });
        }

        public static IEnumerator DefaultUnityWebRequest<TResponse>(RequestHelper options, Action<RequestException, ResponseHelper, TResponse[]> callback)
        {
            return CreateRequestAndRetry(options, (RequestException err, ResponseHelper res) => {
                var body = default(TResponse[]);
                try
                {
                    if (err == null && res.StatusCode != HTTP_NO_CONTENT && res.Data != null && options.ParseResponseBody)
                        body = JsonHelper.ArrayFromJson<TResponse>(res.Text);
                }
                catch (Exception error)
                {
                    DebugLog(options.EnableDebug, string.Format("RestClient - Invalid JSON format\nError: {0}", error.Message), true);
                    err = new RequestException(error.Message);
                }
                finally
                {
                    callback(err, res, body);
                }
            });
        }

        public static Promise<TResponse[]> DefaultUnityWebRequestArrayAsync<TResponse>(RequestHelper options, CancelationToken cancelationToken = default(CancelationToken))
        {
            return CreateRequestAndRetryAsync(options, cancelationToken)
                .Then(res =>
                {
                    try
                    {
                        if (res.StatusCode != HTTP_NO_CONTENT && res.Data != null && options.ParseResponseBody)
                        {
                            return JsonHelper.ArrayFromJson<TResponse>(res.Text);
                        }
                        return default(TResponse[]);
                    }
                    catch (Exception error)
                    {
                        DebugLog(options.EnableDebug, string.Format("RestClient - Invalid JSON format\nError: {0}", error.Message), true);
                        throw new RequestException(error.Message);
                    }
                });
        }

    }
}
