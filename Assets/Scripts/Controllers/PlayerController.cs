using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : AbstractController
{

    // Events

    public void OnPause()
    {
        gameManager.Pause();
    }

    public void OnVerticalAttack()
    {
        if (PassivateCombatInputs) return;
        State.OnVerticalAttack();
    }

    public void OnDashAttack()
    {
        if (PassivateCombatInputs) return;
        State.OnDashAttack();
    }

    public void OnMovement(InputValue value)
    {
        if (PassivateCombatInputs) return;
        movement = value.Get<float>();
    }

    public void OnBackDash()
    {
        if (PassivateCombatInputs) return;
        State.OnBackDash();
    }

    public void OnDeviceLostEvent()
    {
        // TODO Pollish
    }
    
    public void OnDeviceRegainedEvent()
    {
        // TODO Pollish
    }
}
