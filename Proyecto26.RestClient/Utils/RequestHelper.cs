using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Proyecto26
{
    public class RequestHelper
    {
        private string _uri;
        public string Uri
        {
            get { return _uri; }
            set { _uri = value; }
        }

        private string _method;
        public string Method
        {
            get { return _method; }
            set { _method = value; }
        }

        private object _body;
        public object Body
        {
            get { return _body; }
            set { _body = value; }
        }

        private string _bodyString;
        public string BodyString
        {
            get { return _bodyString; }
            set { _bodyString = value; }
        }

        private byte[] _bodyRaw;
        public byte[] BodyRaw
        {
            get { return _bodyRaw; }
            set { _bodyRaw = value; }
        }

        private int? _timeout;
        public int? Timeout
        {
            get { return _timeout; }
            set { _timeout = value; }
        }

        private string _contentType;
        public string ContentType
        {
            get { return _contentType; }
            set { _contentType = value; }
        }

        private int _retries;
        public int Retries
        {
            get { return _retries; }
            set { _retries = value; }
        }

        private float _retrySecondsDelay;
        public float RetrySecondsDelay
        {
            get { return _retrySecondsDelay; }
            set { _retrySecondsDelay = value; }
        }

        private Action<RequestException, int> _retryCallback;
        public Action<RequestException, int> RetryCallback
        {
            get { return _retryCallback; }
            set { _retryCallback = value; }
        }

        private bool _enableDebug;
        public bool EnableDebug
        {
            get { return _enableDebug; }
            set { _enableDebug = value; }
        }

        private bool? _chunkedTransfer;
        public bool? ChunkedTransfer
        {
            get { return _chunkedTransfer; }
            set { _chunkedTransfer = value; }
        }

        private bool? _useHttpContinue;
        public bool? UseHttpContinue
        {
            get { return _useHttpContinue; }
            set { _useHttpContinue = value; }
        }

        private int? _redirectLimit;
        public int? RedirectLimit
        {
            get { return _redirectLimit; }
            set { _redirectLimit = value; }
        }

        private bool _ignoreHttpException;
        public bool IgnoreHttpException
        {
            get { return _ignoreHttpException; }
            set { _ignoreHttpException = value; }
        }

        private WWWForm _formData;
        public WWWForm FormData
        {
            get { return _formData; }
            set { _formData = value; }
        }

        private Dictionary<string, string> _simpleForm;
        public Dictionary<string, string> SimpleForm
        {
            get { return _simpleForm; }
            set { _simpleForm = value; }
        }

        private List<IMultipartFormSection> _formSections;
        public List<IMultipartFormSection> FormSections
        {
            get { return _formSections; }
            set { _formSections = value; }
        }

#if UNITY_2018_1_OR_NEWER
        private CertificateHandler _certificateHandler;
        public CertificateHandler CertificateHandler
        {
            get { return _certificateHandler; }
            set { _certificateHandler = value; }
        }
#endif

        private UploadHandler _uploadHandler;
        public UploadHandler UploadHandler
        {
            get { return _uploadHandler; }
            set { _uploadHandler = value; }
        }

        private DownloadHandler _downloadHandler;
        public DownloadHandler DownloadHandler 
        { 
            get { return _downloadHandler; }
            set { _downloadHandler = value; }
        }

        private Dictionary<string, string> _headers;
        public Dictionary<string, string> Headers 
        { 
            get
            {
                if (_headers == null)
                {
                    _headers = new Dictionary<string, string>();
                }
                return _headers;
            }
            set { _headers = value; } 
        }

        public float UploadProgress
        {
            get 
            {
                float progress = 0;
                if(this.Request != null)
                {
                    progress = this.Request.uploadProgress;
                }
                return progress;
            }
        }

        public ulong UploadedBytes
        {
            get
            {
                ulong bytes = 0;
                if (this.Request != null)
                {
                    bytes = this.Request.uploadedBytes;
                }
                return bytes;
            }
        }

        public float DownloadProgress
        {
            get
            {
                float progress = 0;
                if (this.Request != null)
                {
                    progress = this.Request.downloadProgress;
                }
                return progress;
            }
        }

        public ulong DownloadedBytes
        {
            get
            {
                ulong bytes = 0;
                if (this.Request != null)
                {
                    bytes = this.Request.downloadedBytes;
                }
                return bytes;
            }
        }

        /// <summary>
        /// Internal use
        /// </summary>
        public UnityWebRequest Request { private get; set; }

        /// <summary>
        /// Get the value of a header
        /// </summary>
        /// <returns>The string value of the header.</returns>
        /// <param name="name">The name of the header.</param>
        public string GetHeader(string name)
        {
            string headerValue;
            if (this.Request != null)
            {
                headerValue = this.Request.GetRequestHeader(name);
            }
            else
            {
                this.Headers.TryGetValue(name, out headerValue);
            }
            return headerValue;
        }

        private bool _isAborted;
        public bool IsAborted
        {
            get { return _isAborted; }
            set { _isAborted = value; }
        }

        /// <summary>
        /// Abort the request manually
        /// </summary>
        public void Abort() {
            if (this.Request != null && !this.IsAborted)
            {
                try
                {
                    this.IsAborted = true;
                    this.Request.Abort();
                }
                finally
                {
                    this.Request = null;
                }
            }
        }
    }
}
