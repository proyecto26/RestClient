using RSG;
using System;
using UnityEngine.Networking;
using System.Collections.Generic;

namespace Proyecto26
{
    public static class RestClient
    {
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
        /// Load data from the server using a HTTP GET request
        /// </summary>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        public static void Get(string url, Action<Exception, ResponseHelper> callback)
        {
            Get(new RequestHelper { url = url }, callback);
        }

        /// <summary>
        /// Load data from the server using a HTTP GET request
        /// </summary>
        /// <param name="options">An options object.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        public static void Get(RequestHelper options, Action<Exception, ResponseHelper> callback)
        {
            StaticCoroutine.StartCoroutine(HttpBase.DefaultUnityWebRequest(options, null, UnityWebRequest.kHttpVerbGET, callback));
        }

        /// <summary>
        /// Load data from the server using a HTTP GET request
        /// </summary>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        /// <typeparam name="T">The relement type of the response.</typeparam>
        public static void Get<T>(string url, Action<Exception, ResponseHelper, T> callback)
        {
            Get<T>(new RequestHelper { url = url }, callback);
        }

        /// <summary>
        /// Load data from the server using a HTTP GET request
        /// </summary>
        /// <param name="options">An options object.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        /// <typeparam name="T">The relement type of the response.</typeparam>
        public static void Get<T>(RequestHelper options, Action<Exception, ResponseHelper, T> callback)
        {
            StaticCoroutine.StartCoroutine(HttpBase.DefaultUnityWebRequest<T>(options, null, UnityWebRequest.kHttpVerbGET, callback));
        }

        /// <summary>
        /// Load a JSON array from the server using a HTTP GET request
        /// </summary>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        /// <typeparam name="T">The element type of the array.</typeparam>
        public static void GetArray<T>(string url, Action<Exception, T[]> callback)
        {
            GetArray<T>(new RequestHelper { url = url }, callback);
        }

        /// <summary>
        /// Load a JSON array from the server using a HTTP GET request
        /// </summary>
        /// <param name="options">An options object.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        /// <typeparam name="T">The element type of the array.</typeparam>
        public static void GetArray<T>(RequestHelper options, Action<Exception, T[]> callback)
        {
            StaticCoroutine.StartCoroutine(HttpGet.GetArrayUnityWebRequest<T>(options, callback));
        }

        /// <summary>
        /// Load data from the server using a HTTP POST request.
        /// </summary>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="bodyJson">A plain object that is sent to the server with the request.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        public static void Post(string url, object bodyJson, Action<Exception, ResponseHelper> callback)
        {
            Post(new RequestHelper { url = url }, bodyJson, callback);
        }

        /// <summary>
        /// Load data from the server using a HTTP POST request.
        /// </summary>
        /// <param name="options">An options object.</param>
        /// <param name="bodyJson">A plain object that is sent to the server with the request.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        public static void Post(RequestHelper options, object bodyJson, Action<Exception, ResponseHelper> callback)
        {
            StaticCoroutine.StartCoroutine(HttpBase.DefaultUnityWebRequest(options, bodyJson, UnityWebRequest.kHttpVerbPOST, callback));
        }

        /// <summary>
        /// Load data from the server using a HTTP POST request.
        /// </summary>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="bodyJson">A plain object that is sent to the server with the request.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static void Post<T>(string url, object bodyJson, Action<Exception, ResponseHelper, T> callback)
        {
            Post<T>(new RequestHelper { url = url }, bodyJson, callback);
        }

        /// <summary>
        /// Load data from the server using a HTTP POST request.
        /// </summary>
        /// <param name="options">An options object.</param>
        /// <param name="bodyJson">A plain object that is sent to the server with the request.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static void Post<T>(RequestHelper options, object bodyJson, Action<Exception, ResponseHelper, T> callback)
        {
            StaticCoroutine.StartCoroutine(HttpBase.DefaultUnityWebRequest<T>(options, bodyJson, UnityWebRequest.kHttpVerbPOST, callback));
        }

        /// <summary>
        /// Load data from the server using a HTTP PUT request.
        /// </summary>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="bodyJson">A plain object that is sent to the server with the request.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        public static void Put(string url, object bodyJson, Action<Exception, ResponseHelper> callback)
        {
            Put(new RequestHelper { url = url }, bodyJson, callback);
        }

        /// <summary>
        /// Load data from the server using a HTTP PUT request.
        /// </summary>
        /// <param name="options">An options object.</param>
        /// <param name="bodyJson">A plain object that is sent to the server with the request.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        public static void Put(RequestHelper options, object bodyJson, Action<Exception, ResponseHelper> callback)
        {
            StaticCoroutine.StartCoroutine(HttpBase.DefaultUnityWebRequest(options, bodyJson, UnityWebRequest.kHttpVerbPUT, callback));
        }

        /// <summary>
        /// Load data from the server using a HTTP PUT request.
        /// </summary>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="bodyJson">A plain object that is sent to the server with the request.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static void Put<T>(string url, object bodyJson, Action<Exception, ResponseHelper, T> callback)
        {
            Put<T>(new RequestHelper { url = url }, bodyJson, callback);
        }

        /// <summary>
        /// Load data from the server using a HTTP PUT request.
        /// </summary>
        /// <param name="options">An options object.</param>
        /// <param name="bodyJson">A plain object that is sent to the server with the request.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static void Put<T>(RequestHelper options, object bodyJson, Action<Exception, ResponseHelper, T> callback)
        {
            StaticCoroutine.StartCoroutine(HttpBase.DefaultUnityWebRequest<T>(options, bodyJson, UnityWebRequest.kHttpVerbPUT, callback));
        }

        /// <summary>
        /// Delete the specified resource identified by the URI.
        /// </summary>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        public static void Delete(string url, Action<Exception, ResponseHelper> callback)
        {
            Delete(new RequestHelper { url = url }, callback);
        }

        /// <summary>
        /// Delete the specified resource identified by the URI.
        /// </summary>
        /// <param name="options">An options object.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        public static void Delete(RequestHelper options, Action<Exception, ResponseHelper> callback)
        {
            StaticCoroutine.StartCoroutine(HttpDelete.DeleteUnityWebRequest(options, callback));
        }

        #endregion

        #region Promises

        /// <summary>
        /// Load data from the server using a HTTP GET request
        /// </summary>
        /// <returns>Returns a promise for a string value.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        public static IPromise<ResponseHelper> Get(string url)
        {
            return Get(new RequestHelper { url = url });
        }

        /// <summary>
        /// Load data from the server using a HTTP GET request
        /// </summary>
        /// <returns>Returns a promise for a string value.</returns>
        /// <param name="options">An options object.</param>
        public static IPromise<ResponseHelper> Get(RequestHelper options)
        {
            var promise = new Promise<ResponseHelper>();
            Get(options, promise.Promisify);
            return promise;
        }

        /// <summary>
        /// Load data from the server using a HTTP GET request
        /// </summary>
        /// <returns>Returns a promise for a value of a specified type.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static IPromise<T> Get<T>(string url)
        {
            return Get<T>(new RequestHelper { url = url });
        }

        /// <summary>
        /// Load data from the server using a HTTP GET request
        /// </summary>
        /// <returns>Returns a promise for a value of a specified type.</returns>
        /// <param name="options">An options object.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static IPromise<T> Get<T>(RequestHelper options)
        {
            var promise = new Promise<T>();
            Get<T>(options, promise.PromisifyHelper);
            return promise;
        }

        /// <summary>
        /// Load data from the server using a HTTP GET request
        /// </summary>
        /// <returns>Returns a promise for an array of values.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <typeparam name="T">The element type of the array.</typeparam>
        public static IPromise<T[]> GetArray<T>(string url)
        {
            return GetArray<T>(new RequestHelper { url = url });
        }

        /// <summary>
        /// Load data from the server using a HTTP GET request
        /// </summary>
        /// <returns>Returns a promise for an array of values.</returns>
        /// <param name="options">An options object.</param>
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
        /// <param name="bodyJson">A plain object that is sent to the server with the request.</param>
        public static IPromise<ResponseHelper> Post(string url, object bodyJson)
        {
            return Post(new RequestHelper { url = url }, bodyJson);
        }

        /// <summary>
        /// Load data from the server using a HTTP POST request.
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="options">An options object.</param>
        /// <param name="bodyJson">A plain object that is sent to the server with the request.</param>
        public static IPromise<ResponseHelper> Post(RequestHelper options, object bodyJson)
        {
            var promise = new Promise<ResponseHelper>();
            Post(options, bodyJson, promise.Promisify);
            return promise;
        }

        /// <summary>
        /// Load data from the server using a HTTP POST request.
        /// </summary>
        /// <returns>Returns a promise for a value of a specified type.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="bodyJson">A plain object that is sent to the server with the request.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static IPromise<T> Post<T>(string url, object bodyJson)
        {
            return Post<T>(new RequestHelper { url = url }, bodyJson);
        }

        /// <summary>
        /// Load data from the server using a HTTP POST request.
        /// </summary>
        /// <returns>Returns a promise for a value of a specified type.</returns>
        /// <param name="options">An options object.</param>
        /// <param name="bodyJson">A plain object that is sent to the server with the request.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static IPromise<T> Post<T>(RequestHelper options, object bodyJson)
        {
            var promise = new Promise<T>();
            Post<T>(options, bodyJson, promise.PromisifyHelper);
            return promise;
        }

        /// <summary>
        /// Load data from the server using a HTTP PUT request.
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="bodyJson">A plain object that is sent to the server with the request.</param>
        public static IPromise<ResponseHelper> Put(string url, object bodyJson)
        {
            return Put(new RequestHelper { url = url }, bodyJson);
        }

        /// <summary>
        /// Load data from the server using a HTTP PUT request.
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="options">An options object.</param>
        /// <param name="bodyJson">A plain object that is sent to the server with the request.</param>
        public static IPromise<ResponseHelper> Put(RequestHelper options, object bodyJson)
        {
            var promise = new Promise<ResponseHelper>();
            Put(options, bodyJson, promise.Promisify);
            return promise;
        }

        /// <summary>
        /// Load data from the server using a HTTP PUT request.
        /// </summary>
        /// <returns>Returns a promise for a value of a specified type.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="bodyJson">A plain object that is sent to the server with the request.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static IPromise<T> Put<T>(string url, object bodyJson)
        {
            return Put<T>(new RequestHelper { url = url }, bodyJson);
        }

        /// <summary>
        /// Load data from the server using a HTTP PUT request.
        /// </summary>
        /// <returns>Returns a promise for a value of a specified type.</returns>
        /// <param name="options">An options object.</param>
        /// <param name="bodyJson">A plain object that is sent to the server with the request.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static IPromise<T> Put<T>(RequestHelper options, object bodyJson)
        {
            var promise = new Promise<T>();
            Put<T>(options, bodyJson, promise.PromisifyHelper);
            return promise;
        }

        /// <summary>
        /// Delete the specified resource identified by the URI.
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        public static IPromise<ResponseHelper> Delete(string url)
        {
            return Delete(new RequestHelper { url = url });
        }

        /// <summary>
        /// Delete the specified resource identified by the URI.
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="options">An options object.</param>
        public static IPromise<ResponseHelper> Delete(RequestHelper options)
        {
            var promise = new Promise<ResponseHelper>();
            Delete(options, promise.Promisify);
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
        /// Promisify the specified callback
        /// </summary>
        /// <param name="p">The Promise.</param>
        /// <param name="err">An Exception parameter.</param>
        /// <param name="res">A Response parameter.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        private static void Promisify<T>(this Promise<T> p, Exception err, T res)
        {
            if (err != null) { p.Reject(err); } else { p.Resolve(res); }
        }

        /// <summary>
        /// Promisify the specified callback ignoring the ResponseHelper.
        /// </summary>
        /// <param name="p">The Promise.</param>
        /// <param name="err">An Exception parameter.</param>
        /// <param name="res">A ResponseHelper parameter.</param>
        /// <param name="body">A body of the response.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        private static void PromisifyHelper<T>(this Promise<T> p, Exception err, ResponseHelper res, T body)
        {
            p.Promisify(err, body);
        }

        #endregion
    }
}
