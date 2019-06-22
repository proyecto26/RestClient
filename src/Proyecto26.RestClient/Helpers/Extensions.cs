using System.Text;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace Proyecto26.Common
{
    public static class Extensions
    {
        /// <summary>
        /// Create an object with the response of the server
        /// </summary>
        /// <returns>An object with the response.</returns>
        /// <param name="request">An UnityWebRequest object.</param>
        public static ResponseHelper CreateWebResponse(this UnityWebRequest request)
        {
            return new ResponseHelper(request);
        }

        public static bool IsValidRequest(this UnityWebRequest request, RequestHelper options)
        {
            return request.isDone &&
            !request.isNetworkError &&
            (
                !request.isHttpError || options.IgnoreHttpException
            );
        }
    }
}
