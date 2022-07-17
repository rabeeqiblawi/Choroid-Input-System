using Choroid.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UnityInputActionWrapper : Choroid.Input.InputDetector
{
    public UnityEngine.InputSystem.InputAction inputAction;

    public override InputActionPhase Phase { get; set; }

    public override void TryDetectAction()
    {
        Phase = inputAction.phase;
    }
}
