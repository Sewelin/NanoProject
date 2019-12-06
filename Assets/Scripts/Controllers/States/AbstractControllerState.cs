using System;
using UnityEngine;

public abstract class AbstractControllerState
{
    protected readonly GameManager gameManager;
    protected readonly AbstractController controller;
    protected ControllerStateName nextState = ControllerStateName.Idle;
    protected float movement;

    // Methods
    protected AbstractControllerState(GameManager gameManager, AbstractController controller)
    {
        this.gameManager = gameManager;
        this.controller = controller;
    }
    
    public virtual void Update()
    {
    }

    public virtual void FixedUpdate()
    {
    }

    protected virtual void Exit()
    {
    }
    
    // Events
    
    public virtual void OnVerticalAttack()
    {
        Exit();
        controller.SetState(new VerticalState(gameManager, controller, controller.dir));
    }

    public virtual void OnDashAttack()
    {
        Exit();
        controller.SetState(new DashState(gameManager, controller, controller.dir));
    }

    public virtual void OnBackDash()
    {
        Exit();
        controller.SetState(new BackDashState(gameManager, controller, controller.dir));
    }

    public abstract ControllerStateName Name();
}
