using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Choroid.Input
{
    /// <summary>
    /// Uses multiple InputDetectors that will act as one when all are triggered.
    /// </summary>
    public class CompositeInputDetector : InputDetector
    {
        //TODO make sequential VRAction.
        public List<InputDetector> VRActions;

        public override InputActionPhase Phase { get; set; }

        public override void TryDetectAction()
        {
            if (VRActions.TrueForAll(_ => _.Phase == InputActionPhase.Performed))
            {
                Phase = InputActionPhase.Performed;
                OnActionPerformed.Invoke();
            }
        }
    }
}