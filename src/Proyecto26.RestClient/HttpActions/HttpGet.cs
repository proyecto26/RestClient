using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

namespace Proyecto26.RestClient
{
    public static class HttpGet
    {
        public static IEnumerator GetUnityWebRequest<T>(string url, Action<Exception, T> callback)
        {
            using (var request = UnityWebRequest.Get(url))
            {
                yield return request.SendWebRequest();
                T response = default(T);
                if (request.isDone)
                {
                    response = JsonUtility.FromJson<T>(request.downloadHandler.text);
                    callback(null, response);
                }
                else
                {
                    callback(new Exception(request.error), response);
                }
            }
        }

        public static IEnumerator GetArrayUnityWebRequest<T>(string url, Action<Exception, T[]> callback)
        {
            using (var request = UnityWebRequest.Get(url))
            {
                yield return request.SendWebRequest();
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
