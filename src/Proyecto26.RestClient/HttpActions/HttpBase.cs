using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace Proyecto26.RestClient
{
    public static class HttpBase
    {
        private static IEnumerator WebRequest(this UnityWebRequest request, object bodyJson)
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(JsonUtility.ToJson(bodyJson).ToCharArray());
            request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            yield return request.SendWebRequest();
        }

        public static IEnumerator DefaultUnityWebRequest(string url, object bodyJson, HttpAction method, Action<Exception, ResponseHelper> callback)
        {
            var request = new UnityWebRequest(url, method.ToString());
            yield return request.WebRequest(bodyJson);
            var response = new ResponseHelper
            {
                statusCode = request.responseCode,
                data = request.downloadHandler.data,
                text = request.downloadHandler.text,
                headers = request.GetResponseHeaders(),
                error = request.error
            };
            if (request.isDone)
            {
                callback(null, response);
            }
            else
            {
                callback(new Exception(request.error), response);
            }
        }
        public static IEnumerator DefaultUnityWebRequest<TResponse>(string url, object bodyJson, HttpAction method, Action<Exception, ResponseHelper, TResponse> callback)
        {
            var request = new UnityWebRequest(url, method.ToString());
            yield return request.WebRequest(bodyJson);
            var response = new ResponseHelper
            {
                statusCode = request.responseCode,
                data = request.downloadHandler.data,
                text = request.downloadHandler.text,
                headers = request.GetResponseHeaders(),
                error = request.error
            };
            if (request.isDone)
            {
                var body = JsonUtility.FromJson<TResponse>(request.downloadHandler.text);
                callback(null, response, body);
            }
            else
            {
                callback(new Exception(request.error), response, default(TResponse));
            }
        }
    }
}
