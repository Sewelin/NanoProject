using System;
using UnityEngine;

public abstract class AbstractControllerState
{
    protected readonly GameManager gameManager;
    protected readonly AbstractController controller;
    protected ControllerStateName nextState = ControllerStateName.Idle;

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

    public abstract ControllerStateName Name();
    
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

    public virtual void OnBow()
    {
        Exit();
        controller.SetState(new BowState(gameManager, controller));
    }

    public void ResetNextState()
    {
        nextState = ControllerStateName.Idle;
    }
}
