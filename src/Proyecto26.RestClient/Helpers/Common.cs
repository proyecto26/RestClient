using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace Proyecto26.Common
{
    public static class Common
    {
        private const string CONTENT_TYPE_HEADER = "Content-Type";
        private const string DEFAULT_CONTENT_TYPE = "application/json";

        private static string GetFormSectionsContentType(out byte[] bodyRaw, RequestHelper options)
        {
            byte[] boundary = UnityWebRequest.GenerateBoundary();
            byte[] formSections = UnityWebRequest.SerializeFormSections(options.FormSections, boundary);
            byte[] terminate = Encoding.UTF8.GetBytes(string.Concat("\r\n--", Encoding.UTF8.GetString(boundary), "--"));
            bodyRaw = new byte[formSections.Length + terminate.Length];
            System.Buffer.BlockCopy(formSections, 0, bodyRaw, 0, formSections.Length);
            System.Buffer.BlockCopy(terminate, 0, bodyRaw, formSections.Length, terminate.Length);
            return string.Concat("multipart/form-data; boundary=", Encoding.UTF8.GetString(boundary));
        }

        private static void ConfigureWebRequestWithOptions(UnityWebRequest request, byte[] bodyRaw, string contentType, RequestHelper options)
        {
#if UNITY_2018_1_OR_NEWER
            if (options.CertificateHandler is CertificateHandler)
                request.certificateHandler = options.CertificateHandler;
#endif
            if (options.UploadHandler is UploadHandler)
                request.uploadHandler = options.UploadHandler;
            if (bodyRaw != null)
            {
                request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
                request.uploadHandler.contentType = contentType;
            }

            if (options.DownloadHandler is DownloadHandler)
            {
                request.downloadHandler = options.DownloadHandler;
                options.ParseResponseBody = (options.DownloadHandler is DownloadHandlerBuffer);
            }
            else
                request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            if (!string.IsNullOrEmpty(contentType))
            {
                request.SetRequestHeader(CONTENT_TYPE_HEADER, contentType);
            }
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
#if !UNITY_2019_3_OR_NEWER
            if (options.ChunkedTransfer.HasValue)
            {
                request.chunkedTransfer = options.ChunkedTransfer.Value;
            }
#endif
            if (options.UseHttpContinue.HasValue)
            {
                request.useHttpContinue = options.UseHttpContinue.Value;
            }
            if (options.RedirectLimit.HasValue)
            {
                request.redirectLimit = options.RedirectLimit.Value;
            }
            options.Request = request;
        }

        /// <summary>
        /// Send the web request to the server
        /// </summary>
        /// <returns>An AsyncOperation object.</returns>
        /// <param name="request">An UnityWebRequest object.</param>
        /// <param name="options">An options object.</param>
        public static AsyncOperation SendWebRequestWithOptions(this UnityWebRequest request, RequestHelper options)
        {
            byte[] bodyRaw = options.BodyRaw;
            string contentType = string.Empty;
            if (!options.Headers.TryGetValue(CONTENT_TYPE_HEADER, out contentType) && options.DefaultContentType)
            {
                contentType = DEFAULT_CONTENT_TYPE;
            }
            if (options.Body != null || !string.IsNullOrEmpty(options.BodyString))
            {
                var bodyString = options.BodyString;
                if (options.Body != null)
                {
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
                contentType = GetFormSectionsContentType(out bodyRaw, options);
            }
            else if (options.FormData is WWWForm)
            {
                //The Content-Type header will be copied from the formData parameter
                contentType = string.Empty;
            }
            if (!string.IsNullOrEmpty(options.ContentType))
            {
                contentType = options.ContentType;
            }

            ConfigureWebRequestWithOptions(request, bodyRaw, contentType, options);
#if UNITY_2017_2_OR_NEWER
            return request.SendWebRequest();
#else
            return request.Send();
#endif
        }
    }
}
