#if NET_40
using System;
using System.Collections;
using System.Collections.Concurrent;
#endif
using UnityEngine;

namespace Proyecto26.Helper
{
    /// <summary>
    /// Original solution from: https://stackoverflow.com/a/53818416/10305444
    /// Should also read: https://gamedev.stackexchange.com/a/195298/126092
    /// </summary>
    /// <example>
    /// Code here will be called in the main thread.
    /// <code>
    /// ExecuteOnMainThread.RunOnMainThread.Enqueue(() => {
    ///     // Any API call using RestClient
    /// });
    /// </code>
    /// </example>
    public class ExecuteOnMainThread : MonoBehaviour
    {
        private static ExecuteOnMainThread _instance;
        public static ExecuteOnMainThread Instance { get { return _instance; } }

        void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
        }

#if NET_40
        /// <summary>
        /// Store all instance of Action's and try to invoke them
        /// </summary>
        public static readonly ConcurrentQueue<Action> RunOnMainThread = new ConcurrentQueue<Action>();

        /// <summary>
        /// Unity's Update method
        /// </summary>
        void Update()
        {
            if (!RunOnMainThread.IsEmpty)
            {
                Action action;
                while (RunOnMainThread.TryDequeue(out action))
                {
                    if (action != null) {
                        action.Invoke();
                        action = null;
                    }
                }
            }
        }
#endif
    }
}