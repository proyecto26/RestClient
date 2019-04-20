using System;
using System.Text;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Proyecto26.Common.Extensions;

namespace Proyecto26
{
    public static class HttpBase
    {
        private const string CONTENT_TYPE_HEADER = "Content-Type";
        private const string CONTENT_TYPE_JSON = "application/json";

        public static IEnumerator CreateRequestAndRetry(RequestHelper options, Action<RequestException, ResponseHelper> callback)
        {
            var retries = 0;
            do
            {
                using (var request = CreateRequest(options))
                {
                    yield return SendWebRequest(request, options);
                    var response = request.CreateWebResponse();
                    if (request.IsValidRequest(options))
                    {
                        DebugLog(options.EnableDebug, string.Format("Url: {0}\nMethod: {1}\nStatus: {2}\nResponse: {3}", options.Uri, options.Method, request.responseCode, response.Text), false);
                        callback(null, response);
                        break;
                    }
                    else if (!options.IsAborted && retries < options.Retries)
                    {
                        yield return new WaitForSeconds(options.RetrySecondsDelay);
                        retries++;
                        if(options.RetryCallback != null)
                        {
                            options.RetryCallback(CreateException(request), retries);
                        }
                        DebugLog(options.EnableDebug, string.Format("Retry Request\nUrl: {0}\nMethod: {1}", options.Uri, options.Method), false);
                    }
                    else
                    {
                        var err = CreateException(request);
                        DebugLog(options.EnableDebug, err, true);
                        callback(err, response);
                        break;
                    }
                }
            }
            while (retries <= options.Retries);
        }

        private static UnityWebRequest CreateRequest(RequestHelper options)
        {
            if (options.FormData is WWWForm && options.Method == UnityWebRequest.kHttpVerbPOST)
            {
                return UnityWebRequest.Post(options.Uri, options.FormData);
            }
            else
            {
                return new UnityWebRequest(options.Uri, options.Method);
            }
        }

        private static RequestException CreateException(UnityWebRequest request)
        {
            return new RequestException(request.error, request.isHttpError, request.isNetworkError, request.responseCode, request.downloadHandler.text);
        }

        private static void DebugLog(bool debugEnabled, object message, bool isError)
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
                if (err == null && !string.IsNullOrEmpty(res.Text))
                {
                    try { 
                        body = JsonUtility.FromJson<TResponse>(res.Text);
                    }
                    catch (Exception error) {
                        DebugLog(options.EnableDebug, string.Format("Invalid JSON format\nError: {0}", error.Message), true);
                    }
                }
                callback(err, res, body);
            });
        }

        public static IEnumerator DefaultUnityWebRequest<TResponse>(RequestHelper options, Action<RequestException, ResponseHelper, TResponse[]> callback)
        {
            return CreateRequestAndRetry(options, (RequestException err, ResponseHelper res) => {
                var body = default(TResponse[]);
                if (err == null && !string.IsNullOrEmpty(res.Text))
                {
                    try { 
                        body = JsonHelper.ArrayFromJson<TResponse>(res.Text);
                    }
                    catch (Exception error)
                    {
                        DebugLog(options.EnableDebug, string.Format("Invalid JSON format\nError: {0}", error.Message), true);
                    }
                }
                callback(err, res, body);
            });
        }

        /// <summary>
        /// Send the web request to the server
        /// </summary>
        /// <returns>An UnityWebRequestAsyncOperation object.</returns>
        /// <param name="request">An UnityWebRequest object.</param>
        /// <param name="options">An options object.</param>
        public static IEnumerator SendWebRequest(UnityWebRequest request, RequestHelper options)
        {
            byte[] bodyRaw = options.BodyRaw;
            string contentType = string.Empty;
            if (!options.Headers.TryGetValue(CONTENT_TYPE_HEADER, out contentType))
            {
                contentType = CONTENT_TYPE_JSON;
            }
            if (options.Body != null || !string.IsNullOrEmpty(options.BodyString))
            {
                var bodyString = options.BodyString;
                if (options.Body != null)
                {
                    bodyString = JsonUtility.ToJson(options.Body);
                }
                bodyRaw = Encoding.UTF8.GetBytes(bodyString.ToCharArray());
            }
            else if (options.SimpleForm != null && options.SimpleForm.Count > 0)
            {
                bodyRaw = UnityWebRequest.SerializeSimpleForm(options.SimpleForm);
                contentType = "application/x-www-form-urlencoded";
            }
            else if (options.FormSections != null && options.FormSections.Count > 0)
            {
                byte[] boundary = UnityWebRequest.GenerateBoundary();
                byte[] formSections = UnityWebRequest.SerializeFormSections(options.FormSections, boundary);
                byte[] terminate = Encoding.UTF8.GetBytes(string.Concat("\r\n--", Encoding.UTF8.GetString(boundary), "--"));
                bodyRaw = new byte[formSections.Length + terminate.Length];
                System.Buffer.BlockCopy(formSections, 0, bodyRaw, 0, formSections.Length);
                System.Buffer.BlockCopy(terminate, 0, bodyRaw, formSections.Length, terminate.Length);
                contentType = string.Concat("multipart/form-data; boundary=", Encoding.UTF8.GetString(boundary));
            }
            else if (options.FormData is WWWForm)
            {
                //The Content-Type header will be copied from the formData parameter
                contentType = string.Empty;
            }
            if (!string.IsNullOrEmpty(options.ContentType))
            {
                contentType = options.ContentType;
            }
#if UNITY_2018_1_OR_NEWER
            if (options.CertificateHandler is CertificateHandler)
                request.certificateHandler = options.CertificateHandler;
#endif
            if (options.UploadHandler is UploadHandler)
                request.uploadHandler = options.UploadHandler;
            if (bodyRaw != null)
            {
                request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
                request.uploadHandler.contentType = contentType;
            }
            if (options.DownloadHandler is DownloadHandler)
                request.downloadHandler = options.DownloadHandler;
            else
                request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            if (!string.IsNullOrEmpty(contentType))
            {
                request.SetRequestHeader(CONTENT_TYPE_HEADER, contentType);
            }
            foreach (var header in RestClient.DefaultRequestHeaders)
            {
                request.SetRequestHeader(header.Key, header.Value);
            }
            foreach (var header in options.Headers)
            {
                request.SetRequestHeader(header.Key, header.Value);
            }
            if (options.Timeout.HasValue)
            {
                request.timeout = options.Timeout.Value;
            }
            if (options.ChunkedTransfer.HasValue)
            {
                request.chunkedTransfer = options.ChunkedTransfer.Value;
            }
            if (options.UseHttpContinue.HasValue)
            {
                request.useHttpContinue = options.UseHttpContinue.Value;
            }
            if (options.RedirectLimit.HasValue)
            {
                request.redirectLimit = options.RedirectLimit.Value;
            }
            options.Request = request;
#if UNITY_2017_2_OR_NEWER
            yield return request.SendWebRequest();
#else
            yield return request.Send();
#endif
        }

    }
}
