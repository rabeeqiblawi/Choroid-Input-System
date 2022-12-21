using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Choroid.Input
{
    public class ChoroidBehavior : MonoBehaviour
    {
        private ChoroidInputManager _choroidInputManager;
        protected ChoroidInputManager ChoroidInputManager
        {
            get
            {
                if (_choroidInputManager == null)
                    _choroidInputManager = ChoroidInputManager.Instance;
                return _choroidInputManager;
            }
        }

        public Transform LeftController => ChoroidInputManager.leftController;
        public Transform RightController => ChoroidInputManager.rightController;
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
