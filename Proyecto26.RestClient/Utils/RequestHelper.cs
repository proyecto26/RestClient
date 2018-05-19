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

        private int? _timeout;
        public int? Timeout
        {
            get { return _timeout; }
            set { _timeout = value; }
        }

        private bool _ignoreHttpException;
        public bool IgnoreHttpException
        {
            get { return _ignoreHttpException; }
            set { _ignoreHttpException = value; }
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

        private string _method;
        public string Method
        {
            get { return _method; }
            set { _method = value; }
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
                if(this.request != null)
                {
                    progress = this.request.uploadProgress;
                }
                return progress;
            }
        }

        public float DownloadProgress
        {
            get
            {
                float progress = 0;
                if (this.request != null)
                {
                    progress = this.request.downloadProgress;
                }
                return progress;
            }
        }

        public string GetHeader(string name)
        {
            string headerValue;
            if(request != null)
            {
                headerValue = request.GetRequestHeader(name);
            }
            else
            {
                this.Headers.TryGetValue(name, out headerValue);
            }
            return headerValue;
        }

        /// <summary>
        /// Internal use
        /// </summary>
        public UnityWebRequest request { private get; set; }
    }
}
