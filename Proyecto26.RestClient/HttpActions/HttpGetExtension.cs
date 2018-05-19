using System;
using System.Collections;
using UnityEngine.Networking;
using Proyecto26.Common.Extensions;

namespace Proyecto26
{
    public static class HttpGetExtension
    {
        /// <summary>
        /// Load an array returned from the server using a HTTP GET request
        /// </summary>
        public static IEnumerator GetArrayUnityWebRequest<T>(RequestHelper options, Action<Exception, T[]> callback)
        {
            using (var request = UnityWebRequest.Get(options.Uri))
            {
                yield return request.SendWebRequest(options);
                if (request.IsValidRequest(options))
                {
                    callback(null, JsonHelper.ArrayFromJson<T>(request.downloadHandler.text));
                }
                else
                {
                    var message = request.error ?? request.downloadHandler.text;
                    callback(new RequestException(message, request.isHttpError, request.isNetworkError, request.responseCode), null);
                }
            }
        }
    }
}
