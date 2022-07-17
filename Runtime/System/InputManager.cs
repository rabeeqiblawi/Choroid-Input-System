using UnityEngine;

namespace Choroid.Input
{
    public class InputManager : MonoBehaviour
    {
        public enum ActoinMap
        {
            inAir,
            grounded,
            human
        }

        public Transform leftController;
        public Transform rightController;
        public Transform hmd;

        private void Start()
        {
            InputDetector.SetupTrackedDevicesForAllActions(leftController, rightController, hmd);
        }

        public static InputManager Instance;

        private void Awake()
        {
            Instance = this;
        }
    }
}

