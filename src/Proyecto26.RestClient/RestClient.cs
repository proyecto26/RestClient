using System;
using RSG;

namespace Proyecto26.RestClient
{
    public static class RestClient
    {
        #region Callbacks

        public static void Get<T>(string url, Action<Exception, T> callback)
        {
            StaticCoroutine.StartCoroutine(HttpGet.GetUnityWebRequest<T>(url, callback));
        }

        public static void GetArray<T>(string url, Action<Exception, T[]> callback)
        {
            StaticCoroutine.StartCoroutine(HttpGet.GetArrayUnityWebRequest<T>(url, callback));
        }

        public static void Post(string url, object bodyJson, Action<Exception, ResponseHelper> callback)
        {
            StaticCoroutine.StartCoroutine(HttpBase.DefaultUnityWebRequest(url, bodyJson, HttpAction.POST, callback));
        }

        public static void Post<T>(string url, object bodyJson, Action<Exception, ResponseHelper, T> callback)
        {
            StaticCoroutine.StartCoroutine(HttpBase.DefaultUnityWebRequest<T>(url, bodyJson, HttpAction.POST, callback));
        }

        public static void Put(string url, object bodyJson, Action<Exception, ResponseHelper> callback)
        {
            StaticCoroutine.StartCoroutine(HttpBase.DefaultUnityWebRequest(url, bodyJson, HttpAction.PUT, callback));
        }

        public static void Put<T>(string url, object bodyJson, Action<Exception, ResponseHelper, T> callback)
        {
            StaticCoroutine.StartCoroutine(HttpBase.DefaultUnityWebRequest<T>(url, bodyJson, HttpAction.PUT, callback));
        }

        public static void Delete(string url, Action<Exception, ResponseHelper> callback)
        {
            StaticCoroutine.StartCoroutine(HttpDelete.DeleteUnityWebRequest(url, callback));
        }

        #endregion

        #region Promises

        public static IPromise<T> Get<T>(string url)
        {
            var promise = new Promise<T>();
            Get<T>(url, promise.Denodeify);
            return promise;
        }

        public static IPromise<T[]> GetArray<T>(string url)
        {
            var promise = new Promise<T[]>();
            GetArray<T>(url, promise.Denodeify);
            return promise;
        }

        public static IPromise<ResponseHelper> Post(string url, object bodyJson)
        {
            var promise = new Promise<ResponseHelper>();
            Post(url, bodyJson, promise.Denodeify);
            return promise;
        }

        public static IPromise<T> Post<T>(string url, object bodyJson)
        {
            var promise = new Promise<T>();
            Post<T>(url, bodyJson, promise.DenodeifyHelper);
            return promise;
        }

        public static IPromise<ResponseHelper> Put(string url, object bodyJson)
        {
            var promise = new Promise<ResponseHelper>();
            Put(url, bodyJson, promise.Denodeify);
            return promise;
        }

        public static IPromise<T> Put<T>(string url, object bodyJson)
        {
            var promise = new Promise<T>();
            Put<T>(url, bodyJson, promise.DenodeifyHelper);
            return promise;
        }

        public static IPromise<ResponseHelper> Delete(string url)
        {
            var promise = new Promise<ResponseHelper>();
            Delete(url, promise.Denodeify);
            return promise;
        }

        #endregion

        private static void Denodeify<T>(this Promise<T> p, Exception err, T res)
        {
            if (err != null) p.Reject(err); else p.Resolve(res);
        }

        private static void DenodeifyHelper<T>(this Promise<T> p, Exception err, ResponseHelper res, T body)
        {
            p.Denodeify(err, body);
        }
    }
}
