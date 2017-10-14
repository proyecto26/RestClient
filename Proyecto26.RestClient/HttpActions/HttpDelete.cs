using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Networking;

namespace Proyecto26.RestClient
{
    public static class HttpDelete
    {
        public static IEnumerator DeleteUnityWebRequest(string url, Action<Exception, ResponseHelper> callback)
        {
            using (var request = UnityWebRequest.Delete(url))
            {
                yield return request.SendWebRequest();
                var response = new ResponseHelper
                {
                    statusCode = request.responseCode,
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
        }
    }
}
