using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChoroidXR.VRposeInputMapper
{
    public class ChoroidBehavior : MonoBehaviour
    {
        private VRPoseInputManager _choroidInputManager;
        protected VRPoseInputManager ChoroidInputManager
        {
            get
            {
                if (_choroidInputManager == null)
                    _choroidInputManager = VRPoseInputManager.Instance;
                return _choroidInputManager;
            }
        }

        public Transform LeftControllerTransform => ChoroidInputManager.leftController;
        public Transform RightControllerTransform => ChoroidInputManager.rightController;
        public Transform Hmd => ChoroidInputManager.hmd;

        public void Delay(Action action, float duration)
        {
            StartCoroutine(DelayCoroutine(action, duration));
        }
        private IEnumerator DelayCoroutine(Action action, float duration)
        {
            yield return new WaitForSeconds(duration);
            action.Invoke();
        }
    }
}
