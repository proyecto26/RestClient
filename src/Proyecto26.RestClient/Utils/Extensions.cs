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
        public static IEnumerator SendWebRequest(this UnityWebRequest request, RequestHelper options)
        {
            byte[] bodyRaw = options.BodyRaw;
            string contentType = options.ContentType;
            if (options.Body != null || !string.IsNullOrEmpty(options.BodyString))
            {
                var bodyString = options.BodyString;
                if (options.Body != null) {
                    bodyString = JsonUtility.ToJson(options.Body);
                }
                bodyRaw = Encoding.UTF8.GetBytes(bodyString.ToCharArray());
            }
            else if (options.SimpleForm != null && options.SimpleForm.Count > 0)
            {
                bodyRaw = UnityWebRequest.SerializeSimpleForm(options.SimpleForm);
                contentType = "application/x-www-form-urlencoded";
            }
            else if (options.FormSections != null && options.FormSections.Count > 0) 
            {
                byte[] boundary = UnityWebRequest.GenerateBoundary();
                byte[] formSections = UnityWebRequest.SerializeFormSections(options.FormSections, boundary);
                byte[] terminate = Encoding.UTF8.GetBytes(string.Concat("\r\n--", Encoding.UTF8.GetString(boundary), "--"));
                bodyRaw = new byte[formSections.Length + terminate.Length];
                System.Buffer.BlockCopy(formSections, 0, bodyRaw, 0, formSections.Length);
                System.Buffer.BlockCopy(terminate, 0, bodyRaw, formSections.Length, terminate.Length);
                contentType = string.Concat("multipart/form-data; boundary=", Encoding.UTF8.GetString(boundary));
            }
            if (bodyRaw != null) {
                request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
                request.uploadHandler.contentType = contentType;
            }
            if (options.DownloadHandler is DownloadHandler)
                request.downloadHandler = options.DownloadHandler;
            else
                request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", contentType);
            foreach (var header in RestClient.DefaultRequestHeaders)
            {
                request.SetRequestHeader(header.Key, header.Value);
            }
            foreach (var header in options.Headers)
            {
                request.SetRequestHeader(header.Key, header.Value);
            }
            if (options.Timeout.HasValue)
            {
                request.timeout = options.Timeout.Value;
            }
            if (options.ChunkedTransfer.HasValue)
            {
                request.chunkedTransfer = options.ChunkedTransfer.Value;
            }
            options.Request = request;
            yield return request.SendWebRequest();
        }

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
