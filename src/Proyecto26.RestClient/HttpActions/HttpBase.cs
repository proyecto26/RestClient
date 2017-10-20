using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Proyecto26.Common.Extensions;

namespace Proyecto26
{
    public static class HttpBase
    {
        public static IEnumerator DefaultUnityWebRequest(RequestHelper options, object bodyJson, string method, Action<Exception, ResponseHelper> callback)
        {
            using(var request = new UnityWebRequest(options.url, method.ToString()))
            {
                yield return request.SendWebRequest(options, bodyJson);
                var response = request.CreateWebResponse();
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

        public static IEnumerator DefaultUnityWebRequest<TResponse>(RequestHelper options, object bodyJson, string method, Action<Exception, ResponseHelper, TResponse> callback)
        {
            using (var request = new UnityWebRequest(options.url, method.ToString()))
            {
                yield return request.SendWebRequest(options, bodyJson);
                var response = request.CreateWebResponse();
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
