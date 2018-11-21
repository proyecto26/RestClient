using System;
using UnityEngine;
using System.Collections.Generic;
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

        private bool? _chunkedTransfer;
        public bool? ChunkedTransfer
        {
            get { return _chunkedTransfer; }
            set { _chunkedTransfer = value; }
        }

        private bool _ignoreHttpException;
        public bool IgnoreHttpException
        {
            get { return _ignoreHttpException; }
            set { _ignoreHttpException = value; }
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

        /// <summary>
        /// Abort the request manually
        /// </summary>
        public void Abort() {
            if (this.Request != null)
            {
                try
                {
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
