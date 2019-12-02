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
    protected float timer;

    private int _dir;
    protected int Dir {
        get => _dir;
        private set
        {
            if (!controller.characterSpawned) return;
            _dir = value;
            var v = controller.characterInfo.Character.transform.localScale;
            v.x = value;
            controller.characterInfo.Character.transform.localScale = v;
        }
    }

    // Methods
    protected AbstractState(GameManager gameManager, AbstractController controller, int dir, float maxTimer = 0f)
    {
        this.gameManager = gameManager;
        this.controller = controller;
        this.Dir = dir;
        timer = maxTimer;
    }
    
    public virtual void Update()
    {
        Dir = (int)Mathf.Sign(movement); // TODO Dir
    }

    public virtual void FixedUpdate()
    {
        movement = 0f;
    }

    protected void Exit()
    {
    }
    
    // Events
    
    public virtual void OnVerticalAttack()
    {
        Exit();
        controller.SetState(new VerticalState(gameManager, controller, Dir));
    }

    public virtual void OnDashAttack()
    {
        Exit();
        controller.SetState(new DashState(gameManager, controller, Dir));
    }

    public virtual void OnMovement(float movementP)
    {
        movement = movementP;
    }

    public virtual void OnBackDash()
    {
        Exit();
        controller.SetState(new BackDashState(gameManager, controller, Dir));
    }

    public abstract StateName toS();// TODO Suppr
}
