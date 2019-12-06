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
        State.OnVerticalAttack();
    }

    public void OnDashAttack()
    {
        State.OnDashAttack();
    }

    public void OnMovement(InputValue value)
    {
        movement = value.Get<float>();
    }

    public void OnBackDash()
    {
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
    public void OnDisable()
    {
        GetComponent<PlayerInput>().PassivateInput();
    }
    public void OnEnable()
    {
        GetComponent<PlayerInput>().ActivateInput();
    }
}
