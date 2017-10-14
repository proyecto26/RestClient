using UnityEngine;
using System.Collections;

namespace Proyecto26.RestClient
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
                    _runner = new GameObject("Static Corotuine RestClient").AddComponent<CoroutineHolder>();
                }
                return _runner;
            }
        }

        public static void StartCoroutine(IEnumerator corotuine)
        {
            runner.StartCoroutine(corotuine);
        }
    }
}
