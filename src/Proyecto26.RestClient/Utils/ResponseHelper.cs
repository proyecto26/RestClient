using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Networking;

namespace Proyecto26
{
    [Serializable]
    public class ResponseHelper
    {
        private UnityWebRequest request { get; set; }

        public ResponseHelper(UnityWebRequest unityWebRequest)
        {
            request = unityWebRequest;
        }

        public long StatusCode
        {
            get { return request.responseCode; }
        }

        public byte[] Data
        {
            get {
                byte[] _data;
                try
                {
                    _data = request.downloadHandler.data;
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
                    _text = request.downloadHandler.text;
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
            get { return request.error; }
        }

        public Dictionary<string, string> Headers
        {
            get { return request.GetResponseHeaders(); }
        }

        public override string ToString()
        {
            return JsonUtility.ToJson(this, true);
        }
    }
}
