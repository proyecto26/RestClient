using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Networking;

namespace Proyecto26
{
    public class RequestHelper
    {
        public RequestHelper()
        {
            headers = new Dictionary<string, string>();
        }

        public string url;

        public int? timeout;

        public Dictionary<string, string> headers;

        public float uploadProgress {
            get {
                float progress = 0;
                if(this.request != null){
                    progress = this.request.uploadProgress;
                }
                return progress;
            }
        }

        public float downloadProgress
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

        public string GetHeader(string name){
            string headerValue;
            if(request != null)
            {
                headerValue = request.GetRequestHeader(name);
            }
            else
            {
                this.headers.TryGetValue(name, out headerValue);
            }
            return headerValue;
        }

        /// <summary>
        /// Internal use
        /// </summary>
        public UnityWebRequest request { private get; set; }
    }
}
