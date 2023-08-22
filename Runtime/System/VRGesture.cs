using ChoroidXR.Extentions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ChoroidXR.VRposeInputMapper
{
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
        public VelocityEstimator VelocityEstimator
        {
            get
            {
                return _velocityEstimator;
            }
        }
        public new InputActionPhase Phase
        {
            get => _actionDetected;
            set
            {

                prevPhase = _phase;
                _phase = value;
                if (value == InputActionPhase.Performed)
                    DelayResetDetectedState();
            }
        }
        [SerializeField] private VelocityEstimator _velocityEstimator;
        private InputActionPhase _actionDetected = InputActionPhase.Waiting;

        public abstract void ResetAttributes(bool resetPhaseDirectly = false);

        protected void DelayResetDetectedState()
        {
            this.Delay(() => Phase = InputActionPhase.Waiting, ResetTime);
        }
    }
}