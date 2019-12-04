using System;
using UnityEngine;

public abstract class AbstractState
{
    // Inner classes
// TODO Suppr
    /*protected enum StateName
    {
        Idle,
        VerticalAttack,
        DashAttack,
        BackDash
    }
*/
    // Attributes

    protected readonly GameManager gameManager;
    protected readonly AbstractController controller;
    protected StateName nextState = StateName.Idle;
    protected float movement;

    // Methods
    protected AbstractState(GameManager gameManager, AbstractController controller)
    {
        this.gameManager = gameManager;
        this.controller = controller;
        // TODO controller.Dir = 
    }
    
    public virtual void Update()
    {
    }

    public virtual void FixedUpdate()
    {
    }

    protected void Exit()
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

    public virtual void OnMovement(float movementP)
    {
        movement = movementP;
    }

    public virtual void OnBackDash()
    {
        Exit();
        controller.SetState(new BackDashState(gameManager, controller, controller.dir));
    }

    public abstract StateName toS();// TODO Suppr
}
