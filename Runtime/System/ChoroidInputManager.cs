using UnityEngine;

namespace ChoroidXR.VRposeInputMapper
{
    public class ChoroidInputManager : MonoBehaviour
    {
        public Transform leftController;
        public Transform rightController;
        public Transform hmd;

        public static ChoroidInputManager Instance;
        private void Awake()
        {
            Instance = this;
        }
    }
}