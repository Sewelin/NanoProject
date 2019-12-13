using System;
using UnityEngine;

public abstract class AbstractControllerState
{
    protected readonly GameManager gameManager;
    protected readonly AbstractController controller;
    private ControllerStateName _nextState = ControllerStateName.Idle;
    protected float timer;
    protected StateParameters param;
    protected ControllerStateName NextState
    {
        get => _nextState;
        set
        {
            if (Name() == ControllerStateName.Idle
                || (Name() == ControllerStateName.Bow &&
                    timer > gameManager.bowDuration * gameManager.BUFFURINGTIMEPERCENT / 100f)
                || (Name() != ControllerStateName.Idle && Name() != ControllerStateName.Bow &&
                    timer > param.Duration * gameManager.BUFFURINGTIMEPERCENT / 100f)
            )
            {
                _nextState = value;
            }
        }
    }

    // Methods
    protected AbstractControllerState(GameManager gameManager, AbstractController controller)
    {
        this.gameManager = gameManager;
        this.controller = controller;
    }

    public virtual void Update()
    {
        if (controller.backDashCoolDown > 0f) controller.backDashCoolDown -= Time.deltaTime;
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
        if (controller.backDashCoolDown > 0f) return;
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
        NextState = ControllerStateName.Idle;
    }
}
