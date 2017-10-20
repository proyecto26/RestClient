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
                if (request.isDone && !string.IsNullOrEmpty(json))
                {
                    var response = JsonHelper.ArrayFromJson<T>(json);
                    callback(null, response);
                }
                else
                {
                    callback(new Exception(request.error ?? "The response is empty"), null);
                }
            }
        }
    }
}
