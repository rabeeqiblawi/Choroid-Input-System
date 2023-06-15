using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace ChoroidXR.VRposeInputMapper
{
    public class InputAction : MonoBehaviour
    {
        List<InputDetector> Bindings;
        UnityEvent OnActionPerformed;

        private void Start()
        {

        }

        private void Update()
        {
            Bindings.ForEach(_ =>
            {
                if (_.Phase == InputActionPhase.Performed)
                    OnActionPerformed.Invoke();
            });
        }
    }
}

