// Copyright (c) Proyecto 26.
// Licensed under the MIT License.

using System;
using UnityEngine.Networking;
using System.Collections.Generic;

namespace Proyecto26
{
    /// <summary>
    /// RestClient for Unity
    /// </summary>
    public static partial class RestClient
    {
        #region Common

        private static System.Version _version;
        /// <summary>
        /// Gets the version of the RestClient library.
        /// </summary>
        public static System.Version Version
        {
            get
            {
                if (_version == null) {
                    _version = new System.Version("2.6.2");
                }
                return _version;
            }
        }

        private static Dictionary<string, string> _defaultRequestParams;
        /// <summary>
        /// Default query string params.
        /// </summary>
        public static Dictionary<string, string> DefaultRequestParams
        {
            get
            {
                if (_defaultRequestParams == null)
                {
                    _defaultRequestParams = new Dictionary<string, string>();
                }
                return _defaultRequestParams;
            }
            set { _defaultRequestParams = value; }
        }

        /// <summary>
        /// Clear default query string params.
        /// </summary>
        public static void ClearDefaultParams()
        {
            DefaultRequestParams.Clear();
        }

        private static Dictionary<string, string> _defaultRequestHeaders;
        /// <summary>
        /// Default headers.
        /// </summary>
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
        /// Clear default headers.
        /// </summary>
        public static void ClearDefaultHeaders()
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
        /// Load a JSON array from the server using a HTTP POST request.
        /// </summary>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="body">A plain object that is sent to the server with the request.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        /// <typeparam name="T">The element type of the array.</typeparam>
        public static void PostArray<T>(string url, object body, Action<RequestException, ResponseHelper, T[]> callback)
        {
            PostArray<T>(new RequestHelper { Uri = url, Body = body }, callback);
        }

        /// <summary>
        /// Load a JSON array from the server using a HTTP POST request.
        /// </summary>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="bodyString">A string that is sent to the server with the request.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        /// <typeparam name="T">The element type of the array.</typeparam>
        public static void PostArray<T>(string url, string bodyString, Action<RequestException, ResponseHelper, T[]> callback)
        {
            PostArray<T>(new RequestHelper { Uri = url, BodyString = bodyString }, callback);
        }

        /// <summary>
        /// Load a JSON array from the server using a HTTP POST request.
        /// </summary>
        /// <param name="options">The options of the request.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        /// <typeparam name="T">The element type of the array.</typeparam>
        public static void PostArray<T>(RequestHelper options, Action<RequestException, ResponseHelper, T[]> callback)
        {
            options.Method = UnityWebRequest.kHttpVerbPOST;
            StaticCoroutine.StartCoroutine(HttpBase.DefaultUnityWebRequest(options, callback));
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
        /// Load data from the server using a HTTP PATCH request.
        /// </summary>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="body">A plain object that is sent to the server with the request.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        public static void Patch(string url, object body, Action<RequestException, ResponseHelper> callback)
        {
            Patch(new RequestHelper { Uri = url, Body = body }, callback);
        }

        /// <summary>
        /// Load data from the server using a HTTP PATCH request.
        /// </summary>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="bodyString">A string that is sent to the server with the request.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        public static void Patch(string url, string bodyString, Action<RequestException, ResponseHelper> callback)
        {
            Patch(new RequestHelper { Uri = url, BodyString = bodyString }, callback);
        }

        /// <summary>
        /// Load data from the server using a HTTP PATCH request.
        /// </summary>
        /// <param name="options">The options of the request.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        public static void Patch(RequestHelper options, Action<RequestException, ResponseHelper> callback)
        {
            options.Method = "PATCH";
            Request(options, callback);
        }

        /// <summary>
        /// Load data from the server using a HTTP PATCH request.
        /// </summary>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="body">A plain object that is sent to the server with the request.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static void Patch<T>(string url, object body, Action<RequestException, ResponseHelper, T> callback)
        {
            Patch<T>(new RequestHelper { Uri = url, Body = body }, callback);
        }

        /// <summary>
        /// Load data from the server using a HTTP PATCH request.
        /// </summary>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="bodyString">A string that is sent to the server with the request.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static void Patch<T>(string url, string bodyString, Action<RequestException, ResponseHelper, T> callback)
        {
            Patch<T>(new RequestHelper { Uri = url, BodyString = bodyString }, callback);
        }

        /// <summary>
        /// Load data from the server using a HTTP PATCH request.
        /// </summary>
        /// <param name="options">The options of the request.</param>
        /// <param name="callback">A callback function that is executed when the request is finished.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static void Patch<T>(RequestHelper options, Action<RequestException, ResponseHelper, T> callback)
        {
            options.Method = "PATCH";
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
