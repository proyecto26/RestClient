using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Networking;

namespace Proyecto26
{
    [Serializable]
    public class ResponseHelper
    {
        /// <summary>
        /// The UnityWebRequest used in the current request.
        /// </summary>
        public UnityWebRequest Request { get; private set; }

        public ResponseHelper(UnityWebRequest request)
        {
            Request = request;
        }

        /// <summary>
        /// The numeric HTTP response code returned by the server.
        /// </summary>
        public long StatusCode
        {
            get { return Request.responseCode; }
        }

        /// <summary>
        /// Returns the raw bytes downloaded from the remote server, or null.
        /// </summary>
        public byte[] Data
        {
            get {
                byte[] _data;
                try
                {
                    _data = Request.downloadHandler.data;
                }
                catch (Exception)
                {
                    _data = null;
                }
                return _data;
            }
        }

        /// <summary>
        /// Returns the bytes from data interpreted as a UTF8 string.
        /// </summary>
        public string Text
        {
            get
            {
                string _text;
                try
                {
                    _text = Request.downloadHandler.text;
                }
                catch (Exception)
                {
                    _text = string.Empty;
                }
                return _text;
            }
        }

        /// <summary>
        /// A human-readable string describing any system errors encountered by the UnityWebRequest object of this response while handling HTTP requests or responses.
        /// </summary>
        public string Error
        {
            get { return Request.error; }
        }

        /// <summary>
        /// Get response headers
        /// </summary>
        public Dictionary<string, string> Headers
        {
            get { return Request.GetResponseHeaders(); }
        }

        /// <summary>
        /// Get the value of a header
        /// </summary>
        /// <returns>The string value of the header.</returns>
        /// <param name="name">The name of the header.</param>
        public string GetHeader(string name)
        {
            return this.Request.GetResponseHeader(name);
        }

        public override string ToString()
        {
            return JsonUtility.ToJson(this, true);
        }
    }
}
