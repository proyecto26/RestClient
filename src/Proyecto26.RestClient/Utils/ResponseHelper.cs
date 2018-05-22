using System;
using UnityEngine;
using System.Collections.Generic;

namespace Proyecto26
{
    [Serializable]
    public class ResponseHelper
    {
        private long _statusCode;
        public long StatusCode
        {
            get { return _statusCode; }
            set { _statusCode = value; }
        }

        private byte[] _data;
        public byte[] Data
        {
            get { return _data; }
            set { _data = value; }
        }

        private string _text;
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        private string _error;
        public string Error
        {
            get { return _error; }
            set { _error = value; }
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

        public override string ToString()
        {
            return JsonUtility.ToJson(this, true);
        }
    }
}
