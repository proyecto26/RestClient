using UnityEngine;
using System;

namespace Proyecto26.RestClient
{
    public static class JsonHelper
    {
        public static T[] ArrayFromJson<T>(string json)
        {
            string newJson = "{ \"Items\": " + json + "}";
            var wrapper = UnityEngine.JsonUtility.FromJson<Wrapper<T>>(newJson);
            return wrapper.Items;
        }

        public static T[] FromJsonString<T>(string json)
        {
            var wrapper = UnityEngine.JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.Items;
        }

        public static string ArrayToJsonString<T>(T[] array, bool prettyPrint = false)
        {
            var wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return UnityEngine.JsonUtility.ToJson(wrapper, prettyPrint);
        }

        [Serializable]
        private class Wrapper<T>
        {
            public T[] Items;
        }
    }
}
