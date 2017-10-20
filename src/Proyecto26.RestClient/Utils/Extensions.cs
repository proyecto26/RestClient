using System.Text;
using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

namespace Proyecto26.Common.Extensions
{
    public static class Extensions
    {
        /// <summary>
        /// Send the web request to the server
        /// </summary>
        /// <returns>An UnityWebRequestAsyncOperation object.</returns>
        /// <param name="request">An UnityWebRequest object.</param>
        /// <param name="options">An options object.</param>
        /// <param name="bodyJson">A plain object that is sent to the server with the request.</param>
        public static IEnumerator SendWebRequest(this UnityWebRequest request, RequestHelper options, object bodyJson = null)
        {
            if (bodyJson != null)
            {
                byte[] bodyRaw = Encoding.UTF8.GetBytes(JsonUtility.ToJson(bodyJson).ToCharArray());
                request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
            }
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            foreach (var header in RestClient.DefaultRequestHeaders)
            {
                request.SetRequestHeader(header.Key, header.Value);
            }
            foreach (var header in options.headers)
            {
                request.SetRequestHeader(header.Key, header.Value);
            }
            if (options.timeout.HasValue)
            {
                request.timeout = options.timeout.Value;
            }
            options.request = request;
            yield return request.SendWebRequest();
        }

        /// <summary>
        /// Create an object with the response of the server
        /// </summary>
        /// <returns>An object with the response.</returns>
        /// <param name="request">An UnityWebRequest object.</param>
        public static ResponseHelper CreateWebResponse(this UnityWebRequest request)
        {
            return new ResponseHelper
            {
                statusCode = request.responseCode,
                data = request.downloadHandler.data,
                text = request.downloadHandler.text,
                headers = request.GetResponseHeaders(),
                error = request.error
            };
        }
    }
}
