using UnityEngine;
using UnityEngine.InputSystem;

namespace Choroid.Input
{
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

