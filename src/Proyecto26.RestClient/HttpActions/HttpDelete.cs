using System;
using System.Collections;
using UnityEngine.Networking;
using Proyecto26.Common.Extensions;

namespace Proyecto26
{
    public static class HttpDelete
    {
        public static IEnumerator DeleteUnityWebRequest(RequestHelper options, Action<Exception, ResponseHelper> callback)
        {
            using (var request = UnityWebRequest.Delete(options.url))
            {
                yield return request.SendWebRequest(options);
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
    }
}
