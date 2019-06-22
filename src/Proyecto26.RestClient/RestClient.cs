// Copyright (c) Proyecto 26.
// Licensed under the MIT License.

using System;
using UnityEngine.Networking;
using System.Collections.Generic;

namespace Proyecto26
{
    /// <summary>
    /// RestClient for Unity
    /// Version: 2.5.7
    /// </summary>
    public static partial class RestClient
    {
        #region Common

        /// <summary>
        /// The default request headers.
        /// </summary>
        private static Dictionary<string, string> _defaultRequestHeaders;
        public static Dictionary<string, string> DefaultRequestHeaders
        {
            get
            {
                if (_defaultRequestHeaders == null)
                {
                    _defaultRequestHeaders = new Dictionary<string, string>();
                }
                return _defaultRequestHeaders;
            }
            set { _defaultRequestHeaders = value; }
        }

        /// <summary>
        /// Cleans the default headers.
        /// </summary>
        public static void CleanDefaultHeaders()
        {
            DefaultRequestHeaders.Clear();
        }

        #endregion

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
            StaticCoroutine.StartCoroutine(HttpBase.DefaultUnityWebRequest<T>(options, callback));
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
        public static void GetArray<T>(string url, Action<RequestException, ResponseHelper, T[]> callback)
        {
            GetArray<T>(new RequestHelper { Uri = url }, callback);
        }

        /// <summary>
        /// Load a JSON array from the server using a HTTP GET request
        /// </summary>
        /// <param name="options">The options of the request.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        /// <typeparam name="T">The element type of the array.</typeparam>
        public static void GetArray<T>(RequestHelper options, Action<RequestException, ResponseHelper, T[]> callback)
        {
            options.Method = UnityWebRequest.kHttpVerbGET;
            StaticCoroutine.StartCoroutine(HttpBase.DefaultUnityWebRequest<T>(options, callback));
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
            options.Method = UnityWebRequest.kHttpVerbDELETE;
            Request(options, callback);
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
    }
}
