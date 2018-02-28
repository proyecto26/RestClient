using System;
using System.Collections;
using UnityEngine.Networking;
using Proyecto26.Common.Extensions;

namespace Proyecto26
{
    public static class HttpGet
    {
        /// <summary>
        /// Load an array returned from the server using a HTTP GET request
        /// </summary>
        public static IEnumerator GetArrayUnityWebRequest<T>(RequestHelper options, Action<Exception, T[]> callback)
        {
            using (var request = UnityWebRequest.Get(options.url))
            {
                yield return request.SendWebRequest(options);
                var json = request.downloadHandler.text.Trim();
                var responseIsEmpty = string.IsNullOrEmpty(json);
                if (request.isDone && string.IsNullOrEmpty(request.error) && !responseIsEmpty)
                {
                    var response = JsonHelper.ArrayFromJson<T>(json);
                    callback(null, response);
                }
                else
                {
                    var message = request.error;
                    if(responseIsEmpty){
                        message = "The response is empty";
                    }
                    callback(new RequestException(message, request.isHttpError, request.isNetworkError), null);
                }
            }
        }
    }
}
