using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace Proyecto26
{
    public static class HttpBase
    {
        private static IEnumerator SendWebRequest(this UnityWebRequest request, object bodyJson)
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(JsonUtility.ToJson(bodyJson).ToCharArray());
            request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            yield return request.SendWebRequest();
        }

        private static ResponseHelper CreateResponse(this UnityWebRequest request){
            return new ResponseHelper
            {
                statusCode = request.responseCode,
                data = request.downloadHandler.data,
                text = request.downloadHandler.text,
                headers = request.GetResponseHeaders(),
                error = request.error
            };
        }

        public static IEnumerator DefaultUnityWebRequest(string url, object bodyJson, HttpAction method, Action<Exception, ResponseHelper> callback)
        {
            using(var request = new UnityWebRequest(url, method.ToString()))
            {
                yield return request.SendWebRequest(bodyJson);
                var response = request.CreateResponse();
                if (request.isDone)
                {
                    callback(null, response);
                }
                else
                {
                    callback(new Exception(request.error), response);
                }
            }
        }
        public static IEnumerator DefaultUnityWebRequest<TResponse>(string url, object bodyJson, HttpAction method, Action<Exception, ResponseHelper, TResponse> callback)
        {
            using (var request = new UnityWebRequest(url, method.ToString()))
            {
                yield return request.SendWebRequest(bodyJson);
                var response = request.CreateResponse();
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
}
