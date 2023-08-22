using UnityEngine;

namespace ChoroidXR.VRposeInputMapper
{
    public class VRPoseInputManager : MonoBehaviour
    {
        public Transform leftController;
        public Transform rightController;
        public Transform hmd;

        public static VRPoseInputManager Instance;
        private void Awake()
        {
            Instance = this;
        }
    }
}