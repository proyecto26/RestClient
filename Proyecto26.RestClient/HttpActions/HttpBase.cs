using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Proyecto26.Common.Extensions;

namespace Proyecto26
{
    public static class HttpBase
    {
        public static IEnumerator DefaultUnityWebRequest(RequestHelper options, Action<RequestException, ResponseHelper> callback)
        {
            using(var request = new UnityWebRequest(options.Uri, options.Method))
            {
                yield return request.SendWebRequest(options);
                var response = request.CreateWebResponse();
                if (request.IsValidRequest(options))
                {
                    callback(null, response);
                }
                else
                {
                    var message = request.error ?? request.downloadHandler.text;
                    callback(new RequestException(message, request.isHttpError, request.isNetworkError, request.responseCode), response);
                }
            }
        }

        public static IEnumerator DefaultUnityWebRequest<TResponse>(RequestHelper options, Action<RequestException, ResponseHelper, TResponse> callback)
        {
            using (var request = new UnityWebRequest(options.Uri, options.Method))
            {
                yield return request.SendWebRequest(options);
                var response = request.CreateWebResponse();
                if (request.IsValidRequest(options))
                {
                    callback(null, response, JsonUtility.FromJson<TResponse>(request.downloadHandler.text));
                }
                else
                {
                    var message = request.error ?? request.downloadHandler.text;
                    callback(new RequestException(message, request.isHttpError, request.isNetworkError, request.responseCode), response, default(TResponse));
                }
            }
        }
    }
}
