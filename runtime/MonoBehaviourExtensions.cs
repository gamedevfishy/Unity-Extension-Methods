using System;
using System.Collections;
using UnityEngine;

namespace GameDevFishy.ExtensionMethods
{
    public static class MonoBehaviourExtensions
    {
        /// <summary>
        /// Invokes the specified callback after the specified amount of time. The timer uses scaled time to update.
        /// This method starts a coroutine on this MonoBehaviour.
        /// </summary>
        public static void ExecuteInSeconds(this MonoBehaviour monoBehaviour, float delay, Action callback)
        {
            monoBehaviour.StartCoroutine(ExecuteInSecondsCoroutine(delay, callback, false));
        }

        /// <summary>
        /// Invokes the specified callback after the specified amount of real-time. The timer uses unscaled time to update.
        /// This method starts a coroutine on this MonoBehaviour.
        /// </summary>
        public static void ExecuteInSecondsRealtime(this MonoBehaviour monoBehaviour, float delay, Action callback)
        {
            monoBehaviour.StartCoroutine(ExecuteInSecondsCoroutine(delay, callback, true));
        }

        /// <summary>
        /// Invokes the specified callback on the next frame.
        /// This method starts a coroutine on this MonoBehaviour.
        /// </summary>
        public static void ExecuteNextFrame(this MonoBehaviour monoBehaviour, Action callback)
        {
            monoBehaviour.StartCoroutine(ExecuteNextFrameCoroutine(callback));
        }

        private static IEnumerator ExecuteInSecondsCoroutine(float delay, Action callback, bool useRealtime)
        {
            if (useRealtime)
                yield return new WaitForSecondsRealtime(delay);
            else
                yield return new WaitForSeconds(delay);

            callback?.Invoke();
        }

        private static IEnumerator ExecuteNextFrameCoroutine(Action callback)
        {
            yield return null;
            callback?.Invoke();
        }
    }
}