using UnityEngine.Networking;

namespace Proyecto26
{
    public partial class RequestHelper
    {
        /// <summary>
        /// Internal use
        /// </summary>
        public UnityWebRequest Request { private get; set; }

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
        public void Abort()
        {
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
