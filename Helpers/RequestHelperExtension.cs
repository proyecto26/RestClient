using System;
using UnityEngine.Networking;

namespace Proyecto26
{
    public partial class RequestHelper
    {
        /// <summary>
        /// Internal use
        /// </summary>
        public UnityWebRequest Request { private get; set; }

        /// <summary>
        /// Returns a floating-point value between 0.0 and 1.0, indicating the progress of uploading body data to the server.
        /// </summary>
        public float UploadProgress
        {
            get
            {
                float progress = 0;
                if (this.Request != null)
                {
                    progress = this.Request.uploadProgress;
                }
                return progress;
            }
        }

        /// <summary>
        /// Returns the number of bytes of body data the system has uploaded to the remote server. (Read Only)
        /// </summary>
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

        /// <summary>
        /// Returns a floating-point value between 0.0 and 1.0, indicating the progress of downloading body data from the server. (Read Only)
        /// </summary>
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
        /// Returns the number of bytes of body data the system has downloaded from the remote server. (Read Only)
        /// </summary>
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
        /// <summary>
        /// Check if the request was aborted
        /// </summary>
        /// <value>A boolean to know if the request was aborted by the user</value>
        public bool IsAborted
        {
            get { return _isAborted; }
            set { _isAborted = value; }
        }

        
        private bool _defaultContentType = true;

        /// <summary>
        /// Enable or Disable Content Type JSON by default
        /// </summary>
        /// <value>Check if application/json is enabled by default</value>
        public bool DefaultContentType
        {
            get { return _defaultContentType; }
            set { _defaultContentType = value; }
        }

        /// <summary>
        /// Abort the request manually
        /// </summary>
        public void Abort()
        {
            if (!this.IsAborted && this.Request != null)
            {
                try
                {
                    this.IsAborted = true;
                    if (!this.Request.isDone) {
                        this.Request.Abort();
                    }
                }
                catch (Exception error) {
                    HttpBase.DebugLog(this.EnableDebug, error.Message, true);
                }
                finally
                {
                    this.Request = null;
                }
            }
        }
    }
}
