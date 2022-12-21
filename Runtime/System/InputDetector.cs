using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

/// <summary>
/// used as an input to trigger other game events.
/// </summary>

namespace Choroid.Input
{
    public abstract class InputDetector : ChoroidBehavior
    {

        public UnityEvent OnActionPerformed;
        public UnityEvent OnActionCancled;

        protected InputActionPhase prevPhase;
        protected InputActionPhase _phase;
        public InputActionPhase Phase
        {
            get
            {
                return _phase;
            }
            set
            {
                prevPhase = _phase;
                _phase = value;
            }
        }

        private void Start()
        {
            Phase = InputActionPhase.Waiting;//todo trigger on device disconnect 
        }
        protected void Update()
        {
            TryDetectAction();
        }
        public abstract void TryDetectAction();
    }
}
