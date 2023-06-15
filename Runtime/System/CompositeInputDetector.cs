using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ChoroidXR.VRposeInputMapper
{
    /// <summary>
    /// Uses multiple InputDetectors that will act as one when all are triggered.
    /// </summary>
    public class CompositeInputDetector : InputDetector
    {
        //TODO make sequential VRAction.
        public List<InputDetector> Inputs;


        public override void TryDetectAction()
        {

            if (Inputs.TrueForAll(_ => _.Phase == InputActionPhase.Performed))
            {
                Inputs.ForEach(input =>
                {
                    var gesture = input.GetComponent<VRGesture>();
                    if (gesture != null)
                        gesture.ResetAttributes(resetPhaseDirectly: true);
                });
                Phase = InputActionPhase.Performed;
                OnActionPerformed.Invoke();
            }
        }
    }
}