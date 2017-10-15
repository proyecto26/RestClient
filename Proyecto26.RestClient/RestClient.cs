using System;
using RSG;

namespace Proyecto26
{
    public static class RestClient
    {
        #region Callbacks

        /// <summary>
        /// Load data from the server using a HTTP GET request
        /// </summary>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        public static void Get(string url, Action<Exception, string> callback)
        {
            Get<String>(url, callback);
        }

        /// <summary>
        /// Load data from the server using a HTTP GET request
        /// </summary>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        /// <typeparam name="T">The relement type of the response.</typeparam>
        public static void Get<T>(string url, Action<Exception, T> callback)
        {
            StaticCoroutine.StartCoroutine(HttpGet.GetUnityWebRequest<T>(url, callback));
        }

        /// <summary>
        /// Load a JSON array from the server using a HTTP GET request
        /// </summary>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        /// <typeparam name="T">The element type of the array.</typeparam>
        public static void GetArray<T>(string url, Action<Exception, T[]> callback)
        {
            StaticCoroutine.StartCoroutine(HttpGet.GetArrayUnityWebRequest<T>(url, callback));
        }

        /// <summary>
        /// Load data from the server using a HTTP POST request.
        /// </summary>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="bodyJson">A plain object that is sent to the server with the request.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        public static void Post(string url, object bodyJson, Action<Exception, ResponseHelper> callback)
        {
            StaticCoroutine.StartCoroutine(HttpBase.DefaultUnityWebRequest(url, bodyJson, HttpAction.POST, callback));
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
            StaticCoroutine.StartCoroutine(HttpBase.DefaultUnityWebRequest<T>(url, bodyJson, HttpAction.POST, callback));
        }

        /// <summary>
        /// Load data from the server using a HTTP PUT request.
        /// </summary>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="bodyJson">A plain object that is sent to the server with the request.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        public static void Put(string url, object bodyJson, Action<Exception, ResponseHelper> callback)
        {
            StaticCoroutine.StartCoroutine(HttpBase.DefaultUnityWebRequest(url, bodyJson, HttpAction.PUT, callback));
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
            StaticCoroutine.StartCoroutine(HttpBase.DefaultUnityWebRequest<T>(url, bodyJson, HttpAction.PUT, callback));
        }

        /// <summary>
        /// Delete the specified resource identified by the URI.
        /// </summary>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        public static void Delete(string url, Action<Exception, ResponseHelper> callback)
        {
            StaticCoroutine.StartCoroutine(HttpDelete.DeleteUnityWebRequest(url, callback));
        }

        #endregion

        #region Promises

        /// <summary>
        /// Load data from the server using a HTTP GET request
        /// </summary>
        /// <returns>Returns a promise for a string value.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        public static IPromise<String> Get(string url)
        {
            var promise = new Promise<String>();
            Get<String>(url, promise.Promisify);
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
            var promise = new Promise<T>();
            Get<T>(url, promise.Promisify);
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
            var promise = new Promise<T[]>();
            GetArray<T>(url, promise.Promisify);
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
            var promise = new Promise<ResponseHelper>();
            Post(url, bodyJson, promise.Promisify);
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
            var promise = new Promise<T>();
            Post<T>(url, bodyJson, promise.PromisifyHelper);
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
            var promise = new Promise<ResponseHelper>();
            Put(url, bodyJson, promise.Promisify);
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
            var promise = new Promise<T>();
            Put<T>(url, bodyJson, promise.PromisifyHelper);
            return promise;
        }

        /// <summary>
        /// Delete the specified resource identified by the URI.
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        public static IPromise<ResponseHelper> Delete(string url)
        {
            var promise = new Promise<ResponseHelper>();
            Delete(url, promise.Promisify);
            return promise;
        }

        #endregion

        /// <summary>
        /// Promisify the specified callback
        /// </summary>
        /// <param name="p">The Promise.</param>
        /// <param name="err">An Exception parameter.</param>
        /// <param name="res">A Response parameter.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        private static void Promisify<T>(this Promise<T> p, Exception err, T res)
        {
            if (err != null) p.Reject(err); else p.Resolve(res);
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
    }
}
