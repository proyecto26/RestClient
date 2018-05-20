using System;
using System.Collections;
using UnityEngine.Networking;
using Proyecto26.Common.Extensions;

namespace Proyecto26
{
    public static class HttpDelete
    {
        public static IEnumerator DeleteUnityWebRequest(RequestHelper options, Action<RequestException, ResponseHelper> callback)
        {
            using (var request = UnityWebRequest.Delete(options.Uri))
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
    }
}
