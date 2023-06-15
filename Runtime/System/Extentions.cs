using System;
using System.Collections;
using UnityEngine;

namespace ChoroidXR.Extentions
{
    public static class Extentions
    {
        public static void Delay(this MonoBehaviour monoBehaviour, Action action, float duration)
        {
            monoBehaviour.StartCoroutine(DelayCoroutine(action, duration));
        }
        private static IEnumerator DelayCoroutine(Action action, float duration)
        {
            yield return new WaitForSeconds(duration);
            action.Invoke();
        }
        public static void Vector3LerpWithenCoroutine(this MonoBehaviour monoBehaviour, Vector3 start, Vector3 end, float speed, Action<Vector3> update)
        {
            monoBehaviour.StartCoroutine(LerpCoroutine(start, end, speed, update));
        }
        private static IEnumerator LerpCoroutine(Vector3 start, Vector3 end, float speed, Action<Vector3> update)
        {
            float startTime = Time.time;
            float journeyLength = Vector3.Distance(start, end);
            float fractionOfJourney = 0;

            while (fractionOfJourney < 1)
            {
                float distCovered = (Time.time - startTime) * speed;
                fractionOfJourney = distCovered / journeyLength;
                Vector3 output = Vector3.Lerp(start, end, fractionOfJourney);
                update.Invoke(output);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}

