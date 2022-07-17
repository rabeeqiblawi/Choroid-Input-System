using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

/// <summary>
/// used as an input to trigger other game events.
/// </summary>

namespace Choroid.Input
{
    public abstract class InputDetector : MonoBehaviour
    {
        public static Transform LeftControllerTransform;
        public static Transform RightControllerTransform;
        public static Transform HeadSetTransform;
        public UnityEvent OnActionPerformed;
        public abstract InputActionPhase Phase { get; set; }

        protected void Start()
        {
            StartCoroutine(DetectActionCoroutine());
        }
        public static void SetupTrackedDevicesForAllActions(Transform leftController, Transform rightController, Transform HMD)
        {
            LeftControllerTransform = leftController;
            RightControllerTransform = rightController;
            HeadSetTransform = HMD;
        }
        public abstract void TryDetectAction();
        protected IEnumerator DetectActionCoroutine()
        {
            while (Phase == InputActionPhase.Waiting)
            {
                TryDetectAction();
                yield return new WaitForEndOfFrame();
            }
            OnActionPerformed.Invoke();
        }
    }
}
