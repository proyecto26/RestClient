using Proto.Promises;
using System;

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
        public static Promise<ResponseHelper> Request(RequestHelper options)
        {
            var deferred = Promise.NewDeferred<ResponseHelper>();
            Request(options, GetCallback(deferred));
            return deferred.Promise;
        }

        /// <summary>
        /// Create an HTTP request and convert the response.
        /// </summary>
        /// <returns>Returns a promise for a value of a specified type.</returns>
        /// <param name="options">The options of the request.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static Promise<T> Request<T>(RequestHelper options)
        {
            var deferred = Promise.NewDeferred<T>();
            Request<T>(options, GetCallback(deferred));
            return deferred.Promise;
        }

        /// <summary>
        /// Load data from the server using a HTTP GET request.
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        public static Promise<ResponseHelper> Get(string url)
        {
            return Get(new RequestHelper { Uri = url });
        }

        /// <summary>
        /// Load data from the server using a HTTP GET request.
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="options">The options of the request.</param>
        public static Promise<ResponseHelper> Get(RequestHelper options)
        {
            var deferred = Promise.NewDeferred<ResponseHelper>();
            Get(options, GetCallback(deferred));
            return deferred.Promise;
        }

        /// <summary>
        /// Load data from the server using a HTTP GET request.
        /// </summary>
        /// <returns>Returns a promise for a value of a specified type.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static Promise<T> Get<T>(string url)
        {
            return Get<T>(new RequestHelper { Uri = url });
        }

        /// <summary>
        /// Load data from the server using a HTTP GET request.
        /// </summary>
        /// <returns>Returns a promise for a value of a specified type.</returns>
        /// <param name="options">The options of the request.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static Promise<T> Get<T>(RequestHelper options)
        {
            var deferred = Promise.NewDeferred<T>();
            Get<T>(options, GetCallback(deferred));
            return deferred.Promise;
        }

        /// <summary>
        /// Load data from the server using a HTTP GET request.
        /// </summary>
        /// <returns>Returns a promise for an array of values.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <typeparam name="T">The element type of the array.</typeparam>
        public static Promise<T[]> GetArray<T>(string url)
        {
            return GetArray<T>(new RequestHelper { Uri = url });
        }

        /// <summary>
        /// Load data from the server using a HTTP GET request.
        /// </summary>
        /// <returns>Returns a promise for an array of values.</returns>
        /// <param name="options">The options of the request.</param>
        /// <typeparam name="T">The element type of the array.</typeparam>
        public static Promise<T[]> GetArray<T>(RequestHelper options)
        {
            var deferred = Promise.NewDeferred<T[]>();
            GetArray<T>(options, GetCallback(deferred));
            return deferred.Promise;
        }

        /// <summary>
        /// Load data from the server using a HTTP POST request.
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="body">A plain object that is sent to the server with the request.</param>
        public static Promise<ResponseHelper> Post(string url, object body)
        {
            return Post(new RequestHelper { Uri = url, Body = body });
        }

        /// <summary>
        /// Load data from the server using a HTTP POST request.
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="bodyString">A string that is sent to the server with the request.</param>
        public static Promise<ResponseHelper> Post(string url, string bodyString)
        {
            return Post(new RequestHelper { Uri = url, BodyString = bodyString });
        }

        /// <summary>
        /// Load data from the server using a HTTP POST request.
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="options">The options of the request.</param>
        public static Promise<ResponseHelper> Post(RequestHelper options)
        {
            var deferred = Promise.NewDeferred<ResponseHelper>();
            Post(options, GetCallback(deferred));
            return deferred.Promise;
        }

        /// <summary>
        /// Load data from the server using a HTTP POST request.
        /// </summary>
        /// <returns>Returns a promise for a value of a specified type.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="body">A plain object that is sent to the server with the request.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static Promise<T> Post<T>(string url, object body)
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
        public static Promise<T> Post<T>(string url, string bodyString)
        {
            return Post<T>(new RequestHelper { Uri = url, BodyString = bodyString });
        }

        /// <summary>
        /// Load data from the server using a HTTP POST request.
        /// </summary>
        /// <returns>Returns a promise for a value of a specified type.</returns>
        /// <param name="options">The options of the request.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static Promise<T> Post<T>(RequestHelper options)
        {
            var deferred = Promise.NewDeferred<T>();
            Post<T>(options, GetCallback(deferred));
            return deferred.Promise;
        }

        /// <summary>
        /// Load a JSON array from the server using a HTTP POST request.
        /// </summary>
        /// <returns>Returns a promise for an array of values.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="body">A plain object that is sent to the server with the request.</param>
        /// <typeparam name="T">The element type of the array.</typeparam>
        public static Promise<T[]> PostArray<T>(string url, object body)
        {
            return PostArray<T>(new RequestHelper { Uri = url, Body = body });
        }

        /// <summary>
        /// Load a JSON array from the server using a HTTP POST request.
        /// </summary>
        /// <returns>Returns a promise for an array of values.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="bodyString">A string that is sent to the server with the request.</param>
        /// <typeparam name="T">The element type of the array.</typeparam>
        public static Promise<T[]> PostArray<T>(string url, string bodyString)
        {
            return PostArray<T>(new RequestHelper { Uri = url, BodyString = bodyString });
        }

        /// <summary>
        /// Load a JSON array from the server using a HTTP POST request.
        /// </summary>
        /// <returns>Returns a promise for an array of values.</returns>
        /// <param name="options">The options of the request.</param>
        /// <typeparam name="T">The element type of the array.</typeparam>
        public static Promise<T[]> PostArray<T>(RequestHelper options)
        {
            var deferred = Promise.NewDeferred<T[]>();
            PostArray<T>(options, GetCallback(deferred));
            return deferred.Promise;
        }

        /// <summary>
        /// Load data from the server using a HTTP PUT request.
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="body">A plain object that is sent to the server with the request.</param>
        public static Promise<ResponseHelper> Put(string url, object body)
        {
            return Put(new RequestHelper { Uri = url, Body = body });
        }

        /// <summary>
        /// Load data from the server using a HTTP PUT request.
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="bodyString">A string that is sent to the server with the request.</param>
        public static Promise<ResponseHelper> Put(string url, string bodyString)
        {
            return Put(new RequestHelper { Uri = url, BodyString = bodyString });
        }

        /// <summary>
        /// Load data from the server using a HTTP PUT request.
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="options">The options of the request.</param>
        public static Promise<ResponseHelper> Put(RequestHelper options)
        {
            var deferred = Promise.NewDeferred<ResponseHelper>();
            Put(options, GetCallback(deferred));
            return deferred.Promise;
        }

        /// <summary>
        /// Load data from the server using a HTTP PUT request.
        /// </summary>
        /// <returns>Returns a promise for a value of a specified type.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="body">A plain object that is sent to the server with the request.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static Promise<T> Put<T>(string url, object body)
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
        public static Promise<T> Put<T>(string url, string bodyString)
        {
            return Put<T>(new RequestHelper { Uri = url, BodyString = bodyString });
        }

        /// <summary>
        /// Load data from the server using a HTTP PUT request.
        /// </summary>
        /// <returns>Returns a promise for a value of a specified type.</returns>
        /// <param name="options">The options of the request.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static Promise<T> Put<T>(RequestHelper options)
        {
            var deferred = Promise.NewDeferred<T>();
            Put<T>(options, GetCallback(deferred));
            return deferred.Promise;
        }

        /// <summary>
        /// Load data from the server using a HTTP PATCH request.
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="body">A plain object that is sent to the server with the request.</param>
        public static Promise<ResponseHelper> Patch(string url, object body)
        {
            return Patch(new RequestHelper { Uri = url, Body = body });
        }

        /// <summary>
        /// Load data from the server using a HTTP PATCH request.
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="bodyString">A string that is sent to the server with the request.</param>
        public static Promise<ResponseHelper> Patch(string url, string bodyString)
        {
            return Patch(new RequestHelper { Uri = url, BodyString = bodyString });
        }

        /// <summary>
        /// Load data from the server using a HTTP PATCH request.
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="options">The options of the request.</param>
        public static Promise<ResponseHelper> Patch(RequestHelper options)
        {
            var deferred = Promise.NewDeferred<ResponseHelper>();
            Patch(options, GetCallback(deferred));
            return deferred.Promise;
        }

        /// <summary>
        /// Load data from the server using a HTTP PATCH request.
        /// </summary>
        /// <returns>Returns a promise for a value of a specified type.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="body">A plain object that is sent to the server with the request.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static Promise<T> Patch<T>(string url, object body)
        {
            return Patch<T>(new RequestHelper { Uri = url, Body = body });
        }

        /// <summary>
        /// Load data from the server using a HTTP PATCH request.
        /// </summary>
        /// <returns>Returns a promise for a value of a specified type.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        /// <param name="bodyString">A string that is sent to the server with the request.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static Promise<T> Patch<T>(string url, string bodyString)
        {
            return Patch<T>(new RequestHelper { Uri = url, BodyString = bodyString });
        }

        /// <summary>
        /// Load data from the server using a HTTP PATCH request.
        /// </summary>
        /// <returns>Returns a promise for a value of a specified type.</returns>
        /// <param name="options">The options of the request.</param>
        /// <typeparam name="T">The element type of the response.</typeparam>
        public static Promise<T> Patch<T>(RequestHelper options)
        {
            var deferred = Promise.NewDeferred<T>();
            Patch<T>(options, GetCallback(deferred));
            return deferred.Promise;
        }

        /// <summary>
        /// Delete the specified resource identified by the URI.
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        public static Promise<ResponseHelper> Delete(string url)
        {
            return Delete(new RequestHelper { Uri = url });
        }

        /// <summary>
        /// Delete the specified resource identified by the URI.
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="options">The options of the request.</param>
        public static Promise<ResponseHelper> Delete(RequestHelper options)
        {
            var deferred = Promise.NewDeferred<ResponseHelper>();
            Delete(options, GetCallback(deferred));
            return deferred.Promise;
        }

        /// <summary>
        /// Requests the headers that are returned from the server
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="url">A string containing the URL to which the request is sent.</param>
        public static Promise<ResponseHelper> Head(string url)
        {
            return Head(new RequestHelper { Uri = url });
        }

        /// <summary>
        /// Requests the headers that are returned from the server
        /// </summary>
        /// <returns>Returns a promise for a value of type ResponseHelper.</returns>
        /// <param name="options">The options of the request.</param>
        public static Promise<ResponseHelper> Head(RequestHelper options)
        {
            var deferred = Promise.NewDeferred<ResponseHelper>();
            Head(options, GetCallback(deferred));
            return deferred.Promise;
        }

    #endregion

    #region Helpers

        private static Action<RequestException, ResponseHelper> GetCallback(Promise<ResponseHelper>.Deferred deferred)
        {
            return (RequestException error, ResponseHelper response) =>
            {
                if (error != null) { deferred.Reject(error); } else { deferred.Resolve(response); }
            };
        }

        private static Action<RequestException, ResponseHelper, T> GetCallback<T>(Promise<T>.Deferred deferred)
        {
            return (RequestException error, ResponseHelper response, T body) =>
            {
                if (error != null && response != null)
                {
                    error.ServerMessage = response.Error ?? error.Message;
                }
                if (error != null) { deferred.Reject(error); } else { deferred.Resolve(body); }
            };
        }

    #endregion
    }
}