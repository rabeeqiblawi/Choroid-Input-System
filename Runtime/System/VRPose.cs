using UnityEngine;
using UnityEngine.InputSystem;

namespace ChoroidXR.VRposeInputMapper
{/// <summary>
/// Inhiret this class to create a vr pose. All you have to care about is the PoseCondition Propetry,
/// this class is has access to  HMD, RightController and LeftController transforms.
/// use the exposed transforms to make boolean expressions using the differnce in distances
/// and angles between the devicese.
/// return the performed calculations in the getter of the PoseCondition field.  
/// when the condition is true for a defined amount of time it fire registers an input.
/// </summary>
    public abstract class VRPose : InputDetector
    {
        protected float startTime;
        protected bool startTimeSet = false;
        [SerializeField]
        protected float triggerTime = 0.24f;
        public abstract bool PoseCondition { get; }
        public override void TryDetectAction()
        {
            if (PoseCondition)
            {
                if (Phase != InputActionPhase.Performed)
                {
                    if (!startTimeSet)
                        ResetStartTime();
                    if (Time.time > startTime + triggerTime)
                    {
                        Phase = InputActionPhase.Performed;
                        Debug.Log("performed");
                        OnActionPerformed.Invoke();
                    }
                }

            }
            else
            {
                Phase = InputActionPhase.Waiting;
                startTimeSet = false;
                if (prevPhase == InputActionPhase.Performed)
                    OnActionCancled.Invoke();
            }
        }
        private void ResetStartTime()
        {
            startTime = Time.time;
            startTimeSet = true;
        }
    }
}

