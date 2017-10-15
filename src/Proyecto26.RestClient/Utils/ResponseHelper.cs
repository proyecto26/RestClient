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

        public Dictionary<string, string> headers;

        public override string ToString()
        {
            return JsonUtility.ToJson(this, true);
        }
    }
}
