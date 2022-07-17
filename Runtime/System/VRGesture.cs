using Choroid.Extentions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Choroid.Input
{
    [RequireComponent(typeof(VelocityEstimator))]
    public abstract class VRGesture : InputDetector
    {
        public float ResetTime = 0.8f;
        public Vector3 Velocity
        {
            get
            {
                return VelocityEstimator.EstimatedVelocity;
            }
            private set { }
        }
        public float maxVelocity = 2.5f;
        private VelocityEstimator _velocityEstimator;
        public VelocityEstimator VelocityEstimator
        {
            get
            {
                if (_velocityEstimator == null)
                    _velocityEstimator = GetComponent<VelocityEstimator>();
                return _velocityEstimator;
            }
        }
        private InputActionPhase _actionDetected = InputActionPhase.Waiting;
        public override InputActionPhase Phase
        {
            get => _actionDetected;
            set
            {
                if (value == InputActionPhase.Performed)
                    DelayResetDetectedState();
            }
        }

        private void DelayResetDetectedState()
        {
            this.Delay(() => Phase = InputActionPhase.Waiting, ResetTime);
        }
    }
}