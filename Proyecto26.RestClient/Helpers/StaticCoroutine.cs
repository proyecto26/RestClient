using UnityEngine;
using System.Collections;

namespace Proyecto26
{
    public static class StaticCoroutine
    {
        private class CoroutineHolder : MonoBehaviour { }

        private static CoroutineHolder _runner;
        private static CoroutineHolder runner
        {
            get
            {
                if (_runner == null)
                {
                    _runner = new GameObject("Static Coroutine RestClient").AddComponent<CoroutineHolder>();
                    Object.DontDestroyOnLoad(_runner);
                }
                return _runner;
            }
        }

        public static Coroutine StartCoroutine(IEnumerator coroutine)
        {
            return runner.StartCoroutine(coroutine);
        }
    }
}
