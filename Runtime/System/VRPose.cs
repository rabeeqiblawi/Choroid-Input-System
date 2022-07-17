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
        public override InputActionPhase Phase { get; set; }
    }
}
