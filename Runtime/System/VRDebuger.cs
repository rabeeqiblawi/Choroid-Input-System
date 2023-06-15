using TMPro;
using UnityEngine;

namespace ChoroidXR.VRposeInputMapper
{
    public class VRDebuger : MonoBehaviour
    {
        [SerializeField] private TMP_Text debugTextView;
        private string debugLog;
        public static VRDebuger Instance;

        private void Awake()
        {
            Instance = this;
        }

        public void DebugVRText(string debugText)
        {
            if (string.IsNullOrEmpty(debugLog))
                debugLog = debugText;
            else
                debugLog += "\n" + debugText;
            debugTextView.text = debugLog;
        }
    }
}