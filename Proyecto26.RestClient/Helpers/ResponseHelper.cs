using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Networking;

namespace Proyecto26
{
    [Serializable]
    public class ResponseHelper
    {
        public UnityWebRequest Request { get; private set; }

        public ResponseHelper(UnityWebRequest request)
        {
            Request = request;
        }

        public long StatusCode
        {
            get { return Request.responseCode; }
        }

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

        public string Error
        {
            get { return Request.error; }
        }

        public Dictionary<string, string> Headers
        {
            get { return Request.GetResponseHeaders(); }
        }

        public override string ToString()
        {
            return JsonUtility.ToJson(this, true);
        }
    }
}
