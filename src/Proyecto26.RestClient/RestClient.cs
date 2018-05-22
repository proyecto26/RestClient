using RSG;
using System;
using UnityEngine.Networking;
using System.Collections.Generic;

namespace Proyecto26
{
    public static class RestClient
    {
        /// <summary>
        /// The default request headers.
        /// </summary>
        private static Dictionary<string, string> _defaultRequestHeaders;
        public static Dictionary<string, string> DefaultRequestHeaders 
        {
            get 
            {
                if(_defaultRequestHeaders == null)
                {
                    _defaultRequestHeaders = new Dictionary<string, string>();
                }
                return _defaultRequestHeaders;
            }
            set { _defaultRequestHeaders = value; }
        }

        #region Callbacks

        /// <summary>
        /// Create an HTTP request with the specified options and callback.
        /// </summary>
        /// <param name="options">The options of the request.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        public static void Request(RequestHelper options, Action<RequestException, ResponseHelper> callback)
        {
            StaticCoroutine.StartCoroutine(HttpBase.DefaultUnityWebRequest(options, callback));
        }

        /// <summary>
        /// Create an HTTP request with the specified options and callback.
        /// </summary>
        /// <param name="options">The options of the request.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static void Request<T>(RequestHelper options, Action<RequestException, ResponseHelper, T> callback)
        {
            StaticCoroutine.StartCoroutine(HttpBase.DefaultUnityWebRequest(options, callback));
        }

        /// <summary>
        /// Load data from the server using a HTTP GET request.
        /// </summary>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        public static void Get(string url, Action<RequestException, ResponseHelper> callback)
        {
            Get(new RequestHelper { Uri = url }, callback);
        }

        /// <summary>
        /// Load data from the server using a HTTP GET request.
        /// </summary>
        /// <param name="options">The options of the request.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        public static void Get(RequestHelper options, Action<RequestException, ResponseHelper> callback)
        {
            options.Method = UnityWebRequest.kHttpVerbGET;
            Request(options, callback);
        }

        /// <summary>
        /// Load data from the server using a HTTP GET request.
        /// </summary>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static void Get<T>(string url, Action<RequestException, ResponseHelper, T> callback)
        {
            Get<T>(new RequestHelper { Uri = url }, callback);
        }

        /// <summary>
        /// Load data from the server using a HTTP GET request.
        /// </summary>
        /// <param name="options">The options of the request.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static void Get<T>(RequestHelper options, Action<RequestException, ResponseHelper, T> callback)
        {
            options.Method = UnityWebRequest.kHttpVerbGET;
            Request(options, callback);
        }

        /// <summary>
        /// Load a JSON array from the server using a HTTP GET request
        /// </summary>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        /// <typeparam name="T">The element type of the array.</typeparam>
        public static void GetArray<T>(string url, Action<RequestException, T[]> callback)
        {
            GetArray<T>(new RequestHelper { Uri = url }, callback);
        }

        /// <summary>
        /// Load a JSON array from the server using a HTTP GET request
        /// </summary>
        /// <param name="options">The options of the request.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        /// <typeparam name="T">The element type of the array.</typeparam>
        public static void GetArray<T>(RequestHelper options, Action<RequestException, T[]> callback)
        {
            StaticCoroutine.StartCoroutine(HttpGetExtension.GetArrayUnityWebRequest<T>(options, callback));
        }

        /// <summary>
        /// Load data from the server using a HTTP POST request.
        /// </summary>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="body">A plain object that is sent to the server with the request.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        public static void Post(string url, object body, Action<RequestException, ResponseHelper> callback)
        {
            Post(new RequestHelper { Uri = url, Body = body }, callback);
        }

        /// <summary>
        /// Load data from the server using a HTTP POST request.
        /// </summary>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="bodyString">A string that is sent to the server with the request.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        public static void Post(string url, string bodyString, Action<RequestException, ResponseHelper> callback)
        {
            Post(new RequestHelper { Uri = url, BodyString = bodyString }, callback);
        }

        /// <summary>
        /// Load data from the server using a HTTP POST request.
        /// </summary>
        /// <param name="options">The options of the request.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        public static void Post(RequestHelper options, Action<RequestException, ResponseHelper> callback)
        {
            options.Method = UnityWebRequest.kHttpVerbPOST;
            Request(options, callback);
        }

        /// <summary>
        /// Load data from the server using a HTTP POST request.
        /// </summary>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="body">A plain object that is sent to the server with the request.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static void Post<T>(string url, object body, Action<RequestException, ResponseHelper, T> callback)
        {
            Post<T>(new RequestHelper { Uri = url, Body = body }, callback);
        }

        /// <summary>
        /// Load data from the server using a HTTP POST request.
        /// </summary>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="bodyString">A string that is sent to the server with the request.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static void Post<T>(string url, string bodyString, Action<RequestException, ResponseHelper, T> callback)
        {
            Post<T>(new RequestHelper { Uri = url, BodyString = bodyString }, callback);
        }

        /// <summary>
        /// Load data from the server using a HTTP POST request.
        /// </summary>
        /// <param name="options">The options of the request.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static void Post<T>(RequestHelper options, Action<RequestException, ResponseHelper, T> callback)
        {
            options.Method = UnityWebRequest.kHttpVerbPOST;
            Request(options, callback);
        }

        /// <summary>
        /// Load data from the server using a HTTP PUT request.
        /// </summary>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="body">A plain object that is sent to the server with the request.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        public static void Put(string url, object body, Action<RequestException, ResponseHelper> callback)
        {
            Put(new RequestHelper { Uri = url, Body = body }, callback);
        }

        /// <summary>
        /// Load data from the server using a HTTP PUT request.
        /// </summary>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="bodyString">A string that is sent to the server with the request.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        public static void Put(string url, string bodyString, Action<RequestException, ResponseHelper> callback)
        {
            Put(new RequestHelper { Uri = url, BodyString = bodyString }, callback);
        }

        /// <summary>
        /// Load data from the server using a HTTP PUT request.
        /// </summary>
        /// <param name="options">The options of the request.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        public static void Put(RequestHelper options, Action<RequestException, ResponseHelper> callback)
        {
            options.Method = UnityWebRequest.kHttpVerbPUT;
            Request(options, callback);
        }

        /// <summary>
        /// Load data from the server using a HTTP PUT request.
        /// </summary>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="body">A plain object that is sent to the server with the request.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static void Put<T>(string url, object body, Action<RequestException, ResponseHelper, T> callback)
        {
            Put<T>(new RequestHelper { Uri = url, Body = body }, callback);
        }

        /// <summary>
        /// Load data from the server using a HTTP PUT request.
        /// </summary>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="bodyString">A string that is sent to the server with the request.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static void Put<T>(string url, string bodyString, Action<RequestException, ResponseHelper, T> callback)
        {
            Put<T>(new RequestHelper { Uri = url, BodyString = bodyString }, callback);
        }

        /// <summary>
        /// Load data from the server using a HTTP PUT request.
        /// </summary>
        /// <param name="options">The options of the request.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static void Put<T>(RequestHelper options, Action<RequestException, ResponseHelper, T> callback)
        {
            options.Method = UnityWebRequest.kHttpVerbPUT;
            Request(options, callback);
        }

        /// <summary>
        /// Delete the specified resource identified by the URI.
        /// </summary>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        public static void Delete(string url, Action<RequestException, ResponseHelper> callback)
        {
            Delete(new RequestHelper { Uri = url }, callback);
        }

        /// <summary>
        /// Delete the specified resource identified by the URI.
        /// </summary>
        /// <param name="options">The options of the request.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        public static void Delete(RequestHelper options, Action<RequestException, ResponseHelper> callback)
        {
            StaticCoroutine.StartCoroutine(HttpDelete.DeleteUnityWebRequest(options, callback));
        }

        /// <summary>
        /// Request the headers that are returned from the server
        /// </summary>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        public static void Head(string url, Action<RequestException, ResponseHelper> callback)
        {
            Head(new RequestHelper { Uri = url }, callback);
        }

        /// <summary>
        /// Request the headers that are returned from the server
        /// </summary>
        /// <param name="options">The options of the request.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        public static void Head(RequestHelper options, Action<RequestException, ResponseHelper> callback)
        {
            options.Method = UnityWebRequest.kHttpVerbHEAD;
            Request(options, callback);
        }

        #endregion

        #region Promises

        /// <summary>
        /// Create an HTTP request and return a promise.
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="options">The options of the request.</param>
        public static IPromise<ResponseHelper> Request(RequestHelper options)
        {
            var promise = new Promise<ResponseHelper>();
            Request(options, promise.Promisify);
            return promise;
        }

        /// <summary>
        /// Create an HTTP request and convert the response.
        /// </summary>
        /// <returns>Returns a promise for a value of a specified type.</returns>
        /// <param name="options">The options of the request.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static IPromise<T> Request<T>(RequestHelper options)
        {
            var promise = new Promise<T>();
            Request<T>(options, promise.Promisify);
            return promise;
        }

        /// <summary>
        /// Load data from the server using a HTTP GET request.
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        public static IPromise<ResponseHelper> Get(string url)
        {
            return Get(new RequestHelper { Uri = url });
        }

        /// <summary>
        /// Load data from the server using a HTTP GET request.
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="options">The options of the request.</param>
        public static IPromise<ResponseHelper> Get(RequestHelper options)
        {
            var promise = new Promise<ResponseHelper>();
            Get(options, promise.Promisify);
            return promise;
        }

        /// <summary>
        /// Load data from the server using a HTTP GET request.
        /// </summary>
        /// <returns>Returns a promise for a value of a specified type.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static IPromise<T> Get<T>(string url)
        {
            return Get<T>(new RequestHelper { Uri = url });
        }

        /// <summary>
        /// Load data from the server using a HTTP GET request.
        /// </summary>
        /// <returns>Returns a promise for a value of a specified type.</returns>
        /// <param name="options">The options of the request.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static IPromise<T> Get<T>(RequestHelper options)
        {
            var promise = new Promise<T>();
            Get<T>(options, promise.Promisify);
            return promise;
        }

        /// <summary>
        /// Load data from the server using a HTTP GET request.
        /// </summary>
        /// <returns>Returns a promise for an array of values.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <typeparam name="T">The element type of the array.</typeparam>
        public static IPromise<T[]> GetArray<T>(string url)
        {
            return GetArray<T>(new RequestHelper { Uri = url });
        }

        /// <summary>
        /// Load data from the server using a HTTP GET request.
        /// </summary>
        /// <returns>Returns a promise for an array of values.</returns>
        /// <param name="options">The options of the request.</param>
        /// <typeparam name="T">The element type of the array.</typeparam>
        public static IPromise<T[]> GetArray<T>(RequestHelper options)
        {
            var promise = new Promise<T[]>();
            GetArray<T>(options, promise.Promisify);
            return promise;
        }

        /// <summary>
        /// Load data from the server using a HTTP POST request.
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="body">A plain object that is sent to the server with the request.</param>
        public static IPromise<ResponseHelper> Post(string url, object body)
        {
            return Post(new RequestHelper { Uri = url, Body = body });
        }

        /// <summary>
        /// Load data from the server using a HTTP POST request.
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="bodyString">A string that is sent to the server with the request.</param>
        public static IPromise<ResponseHelper> Post(string url, string bodyString)
        {
            return Post(new RequestHelper { Uri = url, BodyString = bodyString });
        }

        /// <summary>
        /// Load data from the server using a HTTP POST request.
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="options">The options of the request.</param>
        public static IPromise<ResponseHelper> Post(RequestHelper options)
        {
            var promise = new Promise<ResponseHelper>();
            Post(options, promise.Promisify);
            return promise;
        }

        /// <summary>
        /// Load data from the server using a HTTP POST request.
        /// </summary>
        /// <returns>Returns a promise for a value of a specified type.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="body">A plain object that is sent to the server with the request.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static IPromise<T> Post<T>(string url, object body)
        {
            return Post<T>(new RequestHelper { Uri = url, Body = body });
        }

        /// <summary>
        /// Load data from the server using a HTTP POST request.
        /// </summary>
        /// <returns>Returns a promise for a value of a specified type.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="bodyString">A string that is sent to the server with the request.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static IPromise<T> Post<T>(string url, string bodyString)
        {
            return Post<T>(new RequestHelper { Uri = url, BodyString = bodyString });
        }

        /// <summary>
        /// Load data from the server using a HTTP POST request.
        /// </summary>
        /// <returns>Returns a promise for a value of a specified type.</returns>
        /// <param name="options">The options of the request.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static IPromise<T> Post<T>(RequestHelper options)
        {
            var promise = new Promise<T>();
            Post<T>(options, promise.Promisify);
            return promise;
        }

        /// <summary>
        /// Load data from the server using a HTTP PUT request.
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="body">A plain object that is sent to the server with the request.</param>
        public static IPromise<ResponseHelper> Put(string url, object body)
        {
            return Put(new RequestHelper { Uri = url, Body = body });
        }

        /// <summary>
        /// Load data from the server using a HTTP PUT request.
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="bodyString">A string that is sent to the server with the request.</param>
        public static IPromise<ResponseHelper> Put(string url, string bodyString)
        {
            return Put(new RequestHelper { Uri = url, BodyString = bodyString });
        }

        /// <summary>
        /// Load data from the server using a HTTP PUT request.
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="options">The options of the request.</param>
        public static IPromise<ResponseHelper> Put(RequestHelper options)
        {
            var promise = new Promise<ResponseHelper>();
            Put(options, promise.Promisify);
            return promise;
        }

        /// <summary>
        /// Load data from the server using a HTTP PUT request.
        /// </summary>
        /// <returns>Returns a promise for a value of a specified type.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="body">A plain object that is sent to the server with the request.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static IPromise<T> Put<T>(string url, object body)
        {
            return Put<T>(new RequestHelper { Uri = url, Body = body });
        }

        /// <summary>
        /// Load data from the server using a HTTP PUT request.
        /// </summary>
        /// <returns>Returns a promise for a value of a specified type.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="bodyString">A string that is sent to the server with the request.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static IPromise<T> Put<T>(string url, string bodyString)
        {
            return Put<T>(new RequestHelper { Uri = url, BodyString = bodyString });
        }

        /// <summary>
        /// Load data from the server using a HTTP PUT request.
        /// </summary>
        /// <returns>Returns a promise for a value of a specified type.</returns>
        /// <param name="options">The options of the request.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static IPromise<T> Put<T>(RequestHelper options)
        {
            var promise = new Promise<T>();
            Put<T>(options, promise.Promisify);
            return promise;
        }

        /// <summary>
        /// Delete the specified resource identified by the URI.
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        public static IPromise<ResponseHelper> Delete(string url)
        {
            return Delete(new RequestHelper { Uri = url });
        }

        /// <summary>
        /// Delete the specified resource identified by the URI.
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="options">The options of the request.</param>
        public static IPromise<ResponseHelper> Delete(RequestHelper options)
        {
            var promise = new Promise<ResponseHelper>();
            Delete(options, promise.Promisify);
            return promise;
        }

        /// <summary>
        /// Requests the headers that are returned from the server
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        public static IPromise<ResponseHelper> Head(string url)
        {
            return Delete(new RequestHelper { Uri = url });
        }

        /// <summary>
        /// Requests the headers that are returned from the server
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="options">The options of the request.</param>
        public static IPromise<ResponseHelper> Head(RequestHelper options)
        {
            var promise = new Promise<ResponseHelper>();
            Head(options, promise.Promisify);
            return promise;
        }

        #endregion

        #region Common Methods

        /// <summary>
        /// Cleans the default headers.
        /// </summary>
        public static void CleanDefaultHeaders()
        {
            DefaultRequestHeaders.Clear();
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Promisify the specified callback.
        /// </summary>
        /// <param name="promise">The promise to resolve.</param>
        /// <param name="error">The exception of the request.</param>
        /// <param name="response">The response of the request.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        private static void Promisify<T>(this Promise<T> promise, RequestException error, T response)
        {
            if (error != null) { promise.Reject(error); } else { promise.Resolve(response); }
        }

        /// <summary>
        /// Promisify the specified callback ignoring the response.
        /// </summary>
        /// <param name="promise">The promise to resolve.</param>
        /// <param name="error">The exception of the request.</param>
        /// <param name="response">The response of the request.</param>
        /// <param name="body">A body of the response.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        private static void Promisify<T>(this Promise<T> promise, RequestException error, ResponseHelper response, T body)
        {
            if (error != null && response != null) {
                error.ServerMessage = response.Error ?? error.Message;
            }
            promise.Promisify(error, body);
        }

        #endregion
    }
}
