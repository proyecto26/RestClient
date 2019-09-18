using System;
using UnityEngine;

namespace Proyecto26
{
    public static class JsonHelper
    {
        /// <summary>
        /// Get an array of objects when the response is an array "[]" instead of a valid JSON "{}"
        /// </summary>
        /// <returns>An array of objects.</returns>
        /// <param name="json">An array returned from the server.</param>
        /// <typeparam name="T">The element type of the array.</typeparam>
        public static T[] ArrayFromJson<T>(string json)
        {
            string newJson = "{ \"Items\": " + json + "}";
            var wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);
            return wrapper.Items;
        }

        public static T[] FromJsonString<T>(string json)
        {
            var wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.Items;
        }

        public static string ArrayToJsonString<T>(T[] array)
        {
            var wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper);
        }

        public static string ArrayToJsonString<T>(T[] array, bool prettyPrint)
        {
            var wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }

        [Serializable]
        private class Wrapper<T>
        {
            public T[] Items;
        }
    }
}
