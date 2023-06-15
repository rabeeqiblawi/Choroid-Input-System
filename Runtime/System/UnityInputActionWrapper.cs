using ChoroidXR.VRposeInputMapper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UnityInputActionWrapper : ChoroidXR.VRposeInputMapper.InputDetector
{
    public UnityEngine.InputSystem.InputAction inputAction;

    public override void TryDetectAction()
    {
        Phase = inputAction.phase;
    }
}
