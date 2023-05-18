using Proto.Promises;
using UnityEngine.Networking;

namespace Proyecto26
{
    public static partial class RestClient
    {

    #region Promises

        /// <summary>
        /// Create an HTTP request and return a promise.
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="options">The options of the request.</param>
        /// <param name="cancelationToken">The token used to abort the request.</param>
        public static Promise<ResponseHelper> Request(RequestHelper options, CancelationToken cancelationToken = default(CancelationToken))
        {
            return HttpBase.CreateRequestAndRetryAsync(options, cancelationToken);
        }

        /// <summary>
        /// Create an HTTP request and convert the response.
        /// </summary>
        /// <returns>Returns a promise for a value of a specified type.</returns>
        /// <param name="options">The options of the request.</param>
        /// <param name="cancelationToken">The token used to abort the request.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static Promise<T> Request<T>(RequestHelper options, CancelationToken cancelationToken = default(CancelationToken))
        {
            return HttpBase.DefaultUnityWebRequestAsync<T>(options, cancelationToken);
        }

        /// <summary>
        /// Load data from the server using a HTTP GET request.
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="cancelationToken">The token used to abort the request.</param>
        public static Promise<ResponseHelper> Get(string url, CancelationToken cancelationToken = default(CancelationToken))
        {
            return Get(new RequestHelper { Uri = url });
        }

        /// <summary>
        /// Load data from the server using a HTTP GET request.
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="options">The options of the request.</param>
        /// <param name="cancelationToken">The token used to abort the request.</param>
        public static Promise<ResponseHelper> Get(RequestHelper options, CancelationToken cancelationToken = default(CancelationToken))
        {
            options.Method = UnityWebRequest.kHttpVerbGET;
            return HttpBase.CreateRequestAndRetryAsync(options, cancelationToken);
        }

        /// <summary>
        /// Load data from the server using a HTTP GET request.
        /// </summary>
        /// <returns>Returns a promise for a value of a specified type.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static Promise<T> Get<T>(string url, CancelationToken cancelationToken = default(CancelationToken))
        {
            return Get<T>(new RequestHelper { Uri = url });
        }

        /// <summary>
        /// Load data from the server using a HTTP GET request.
        /// </summary>
        /// <returns>Returns a promise for a value of a specified type.</returns>
        /// <param name="options">The options of the request.</param>
        /// <param name="cancelationToken">The token used to abort the request.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static Promise<T> Get<T>(RequestHelper options, CancelationToken cancelationToken = default(CancelationToken))
        {
            options.Method = UnityWebRequest.kHttpVerbGET;
            return HttpBase.DefaultUnityWebRequestAsync<T>(options, cancelationToken);
        }

        /// <summary>
        /// Load data from the server using a HTTP GET request.
        /// </summary>
        /// <returns>Returns a promise for an array of values.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="cancelationToken">The token used to abort the request.</param>
        /// <typeparam name="T">The element type of the array.</typeparam>
        public static Promise<T[]> GetArray<T>(string url, CancelationToken cancelationToken = default(CancelationToken))
        {
            return GetArray<T>(new RequestHelper { Uri = url });
        }

        /// <summary>
        /// Load data from the server using a HTTP GET request.
        /// </summary>
        /// <returns>Returns a promise for an array of values.</returns>
        /// <param name="options">The options of the request.</param>
        /// <param name="cancelationToken">The token used to abort the request.</param>
        /// <typeparam name="T">The element type of the array.</typeparam>
        public static Promise<T[]> GetArray<T>(RequestHelper options, CancelationToken cancelationToken = default(CancelationToken))
        {
            options.Method = UnityWebRequest.kHttpVerbGET;
            return HttpBase.DefaultUnityWebRequestArrayAsync<T>(options, cancelationToken);
        }

        /// <summary>
        /// Load data from the server using a HTTP POST request.
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="body">A plain object that is sent to the server with the request.</param>
        /// <param name="cancelationToken">The token used to abort the request.</param>
        public static Promise<ResponseHelper> Post(string url, object body, CancelationToken cancelationToken = default(CancelationToken))
        {
            return Post(new RequestHelper { Uri = url, Body = body });
        }

        /// <summary>
        /// Load data from the server using a HTTP POST request.
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="bodyString">A string that is sent to the server with the request.</param>
        /// <param name="cancelationToken">The token used to abort the request.</param>
        public static Promise<ResponseHelper> Post(string url, string bodyString, CancelationToken cancelationToken = default(CancelationToken))
        {
            return Post(new RequestHelper { Uri = url, BodyString = bodyString });
        }

        /// <summary>
        /// Load data from the server using a HTTP POST request.
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="options">The options of the request.</param>
        /// <param name="cancelationToken">The token used to abort the request.</param>
        public static Promise<ResponseHelper> Post(RequestHelper options, CancelationToken cancelationToken = default(CancelationToken))
        {
            options.Method = UnityWebRequest.kHttpVerbPOST;
            return HttpBase.CreateRequestAndRetryAsync(options, cancelationToken);
        }

        /// <summary>
        /// Load data from the server using a HTTP POST request.
        /// </summary>
        /// <returns>Returns a promise for a value of a specified type.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="body">A plain object that is sent to the server with the request.</param>
        /// <param name="cancelationToken">The token used to abort the request.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static Promise<T> Post<T>(string url, object body, CancelationToken cancelationToken = default(CancelationToken))
        {
            return Post<T>(new RequestHelper { Uri = url, Body = body });
        }

        /// <summary>
        /// Load data from the server using a HTTP POST request.
        /// </summary>
        /// <returns>Returns a promise for a value of a specified type.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="bodyString">A string that is sent to the server with the request.</param>
        /// <param name="cancelationToken">The token used to abort the request.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static Promise<T> Post<T>(string url, string bodyString, CancelationToken cancelationToken = default(CancelationToken))
        {
            return Post<T>(new RequestHelper { Uri = url, BodyString = bodyString });
        }

        /// <summary>
        /// Load data from the server using a HTTP POST request.
        /// </summary>
        /// <returns>Returns a promise for a value of a specified type.</returns>
        /// <param name="options">The options of the request.</param>
        /// <param name="cancelationToken">The token used to abort the request.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static Promise<T> Post<T>(RequestHelper options, CancelationToken cancelationToken = default(CancelationToken))
        {
            options.Method = UnityWebRequest.kHttpVerbPOST;
            return HttpBase.DefaultUnityWebRequestAsync<T>(options, cancelationToken);
        }

        /// <summary>
        /// Load a JSON array from the server using a HTTP POST request.
        /// </summary>
        /// <returns>Returns a promise for an array of values.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="body">A plain object that is sent to the server with the request.</param>
        /// <param name="cancelationToken">The token used to abort the request.</param>
        /// <typeparam name="T">The element type of the array.</typeparam>
        public static Promise<T[]> PostArray<T>(string url, object body, CancelationToken cancelationToken = default(CancelationToken))
        {
            return PostArray<T>(new RequestHelper { Uri = url, Body = body });
        }

        /// <summary>
        /// Load a JSON array from the server using a HTTP POST request.
        /// </summary>
        /// <returns>Returns a promise for an array of values.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="bodyString">A string that is sent to the server with the request.</param>
        /// <param name="cancelationToken">The token used to abort the request.</param>
        /// <typeparam name="T">The element type of the array.</typeparam>
        public static Promise<T[]> PostArray<T>(string url, string bodyString, CancelationToken cancelationToken = default(CancelationToken))
        {
            return PostArray<T>(new RequestHelper { Uri = url, BodyString = bodyString });
        }

        /// <summary>
        /// Load a JSON array from the server using a HTTP POST request.
        /// </summary>
        /// <returns>Returns a promise for an array of values.</returns>
        /// <param name="options">The options of the request.</param>
        /// <param name="cancelationToken">The token used to abort the request.</param>
        /// <typeparam name="T">The element type of the array.</typeparam>
        public static Promise<T[]> PostArray<T>(RequestHelper options, CancelationToken cancelationToken = default(CancelationToken))
        {
            options.Method = UnityWebRequest.kHttpVerbPOST;
            return HttpBase.DefaultUnityWebRequestArrayAsync<T>(options, cancelationToken);
        }

        /// <summary>
        /// Load data from the server using a HTTP PUT request.
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="body">A plain object that is sent to the server with the request.</param>
        /// <param name="cancelationToken">The token used to abort the request.</param>
        public static Promise<ResponseHelper> Put(string url, object body, CancelationToken cancelationToken = default(CancelationToken))
        {
            return Put(new RequestHelper { Uri = url, Body = body });
        }

        /// <summary>
        /// Load data from the server using a HTTP PUT request.
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="bodyString">A string that is sent to the server with the request.</param>
        /// <param name="cancelationToken">The token used to abort the request.</param>
        public static Promise<ResponseHelper> Put(string url, string bodyString, CancelationToken cancelationToken = default(CancelationToken))
        {
            return Put(new RequestHelper { Uri = url, BodyString = bodyString });
        }

        /// <summary>
        /// Load data from the server using a HTTP PUT request.
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="options">The options of the request.</param>
        /// <param name="cancelationToken">The token used to abort the request.</param>
        public static Promise<ResponseHelper> Put(RequestHelper options, CancelationToken cancelationToken = default(CancelationToken))
        {
            options.Method = UnityWebRequest.kHttpVerbPUT;
            return HttpBase.CreateRequestAndRetryAsync(options, cancelationToken);
        }

        /// <summary>
        /// Load data from the server using a HTTP PUT request.
        /// </summary>
        /// <returns>Returns a promise for a value of a specified type.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="body">A plain object that is sent to the server with the request.</param>
        /// <param name="cancelationToken">The token used to abort the request.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static Promise<T> Put<T>(string url, object body, CancelationToken cancelationToken = default(CancelationToken))
        {
            return Put<T>(new RequestHelper { Uri = url, Body = body });
        }

        /// <summary>
        /// Load data from the server using a HTTP PUT request.
        /// </summary>
        /// <returns>Returns a promise for a value of a specified type.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="bodyString">A string that is sent to the server with the request.</param>
        /// <param name="cancelationToken">The token used to abort the request.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static Promise<T> Put<T>(string url, string bodyString, CancelationToken cancelationToken = default(CancelationToken))
        {
            return Put<T>(new RequestHelper { Uri = url, BodyString = bodyString });
        }

        /// <summary>
        /// Load data from the server using a HTTP PUT request.
        /// </summary>
        /// <returns>Returns a promise for a value of a specified type.</returns>
        /// <param name="options">The options of the request.</param>
        /// <param name="cancelationToken">The token used to abort the request.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static Promise<T> Put<T>(RequestHelper options, CancelationToken cancelationToken = default(CancelationToken))
        {
            options.Method = UnityWebRequest.kHttpVerbPUT;
            return HttpBase.DefaultUnityWebRequestAsync<T>(options, cancelationToken);
        }

        /// <summary>
        /// Load data from the server using a HTTP PATCH request.
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="body">A plain object that is sent to the server with the request.</param>
        /// <param name="cancelationToken">The token used to abort the request.</param>
        public static Promise<ResponseHelper> Patch(string url, object body, CancelationToken cancelationToken = default(CancelationToken))
        {
            return Patch(new RequestHelper { Uri = url, Body = body });
        }

        /// <summary>
        /// Load data from the server using a HTTP PATCH request.
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="bodyString">A string that is sent to the server with the request.</param>
        /// <param name="cancelationToken">The token used to abort the request.</param>
        public static Promise<ResponseHelper> Patch(string url, string bodyString, CancelationToken cancelationToken = default(CancelationToken))
        {
            return Patch(new RequestHelper { Uri = url, BodyString = bodyString });
        }

        /// <summary>
        /// Load data from the server using a HTTP PATCH request.
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="options">The options of the request.</param>
        /// <param name="cancelationToken">The token used to abort the request.</param>
        public static Promise<ResponseHelper> Patch(RequestHelper options, CancelationToken cancelationToken = default(CancelationToken))
        {
            options.Method = "PATCH";
            return HttpBase.CreateRequestAndRetryAsync(options, cancelationToken);
        }

        /// <summary>
        /// Load data from the server using a HTTP PATCH request.
        /// </summary>
        /// <returns>Returns a promise for a value of a specified type.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="body">A plain object that is sent to the server with the request.</param>
        /// <param name="cancelationToken">The token used to abort the request.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static Promise<T> Patch<T>(string url, object body, CancelationToken cancelationToken = default(CancelationToken))
        {
            return Patch<T>(new RequestHelper { Uri = url, Body = body });
        }

        /// <summary>
        /// Load data from the server using a HTTP PATCH request.
        /// </summary>
        /// <returns>Returns a promise for a value of a specified type.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="bodyString">A string that is sent to the server with the request.</param>
        /// <param name="cancelationToken">The token used to abort the request.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static Promise<T> Patch<T>(string url, string bodyString, CancelationToken cancelationToken = default(CancelationToken))
        {
            return Patch<T>(new RequestHelper { Uri = url, BodyString = bodyString });
        }

        /// <summary>
        /// Load data from the server using a HTTP PATCH request.
        /// </summary>
        /// <returns>Returns a promise for a value of a specified type.</returns>
        /// <param name="options">The options of the request.</param>
        /// <param name="cancelationToken">The token used to abort the request.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static Promise<T> Patch<T>(RequestHelper options, CancelationToken cancelationToken = default(CancelationToken))
        {
            options.Method = "PATCH";
            return HttpBase.DefaultUnityWebRequestAsync<T>(options, cancelationToken);
        }

        /// <summary>
        /// Delete the specified resource identified by the URI.
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="cancelationToken">The token used to abort the request.</param>
        public static Promise<ResponseHelper> Delete(string url, CancelationToken cancelationToken = default(CancelationToken))
        {
            return Delete(new RequestHelper { Uri = url });
        }

        /// <summary>
        /// Delete the specified resource identified by the URI.
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="options">The options of the request.</param>
        /// <param name="cancelationToken">The token used to abort the request.</param>
        public static Promise<ResponseHelper> Delete(RequestHelper options, CancelationToken cancelationToken = default(CancelationToken))
        {
            options.Method = UnityWebRequest.kHttpVerbDELETE;
            return HttpBase.CreateRequestAndRetryAsync(options, cancelationToken);
        }

        /// <summary>
        /// Requests the headers that are returned from the server
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="cancelationToken">The token used to abort the request.</param>
        public static Promise<ResponseHelper> Head(string url, CancelationToken cancelationToken = default(CancelationToken))
        {
            return Head(new RequestHelper { Uri = url });
        }

        /// <summary>
        /// Requests the headers that are returned from the server
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="options">The options of the request.</param>
        /// <param name="cancelationToken">The token used to abort the request.</param>
        public static Promise<ResponseHelper> Head(RequestHelper options, CancelationToken cancelationToken = default(CancelationToken))
        {
            options.Method = UnityWebRequest.kHttpVerbHEAD;
            return HttpBase.CreateRequestAndRetryAsync(options, cancelationToken);
        }

    #endregion
    }
}