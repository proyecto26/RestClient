using System;
using UnityEngine;
using System.Collections.Generic;

namespace Proyecto26
{
    [Serializable]
    public class ResponseHelper
    {
        public long statusCode;

        public byte[] data;

        public string text;

        public string error;

        private Dictionary<string, string> _headers;
        public Dictionary<string, string> headers
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
