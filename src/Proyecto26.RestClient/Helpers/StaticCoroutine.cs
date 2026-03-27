using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using Unity.EditorCoroutines.Editor;
#endif

namespace Proyecto26
{
    public static class StaticCoroutine
    {
        private class CoroutineHolder : MonoBehaviour { }

        private static CoroutineHolder _runner;
        private static CoroutineHolder Runner
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
            return Runner.StartCoroutine(coroutine);
        }

        public static void Start(bool useEditor, IEnumerator coroutine)
        {
#if UNITY_EDITOR
            if (useEditor)
            {
                EditorCoroutineUtility.StartCoroutineOwnerless(coroutine);
                return;
            }
#endif
            StartCoroutine(coroutine);
            return;
        }
    }
}
