using System.Text;
using TMPro;
using UnityEngine;

namespace ChoroidXR.VRposeInputMapper
{
    public class VRPoseInputManager : MonoBehaviour
    {
        public Transform leftController;
        public Transform rightController;
        public Transform hmd;

        public static VRPoseInputManager Instance;
        public TMP_Text debugText;
        private StringBuilder logBuilder = new StringBuilder();

        protected void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        public void XRLog(string message)
        {
            logBuilder.AppendLine(message);
            debugText.text = logBuilder.ToString();
            Debug.Log(message);
        }

        protected void LateUpdate()
        {
            logBuilder.Clear();
        }
    }
    public static class XRUtils
    {
        public static void Log(string message)
        {
            VRPoseInputManager.Instance.XRLog(message);
            Debug.Log(message);
        }
    }
}



