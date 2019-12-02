using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalState : AbstractState
{
    public VerticalState(GameManager gameManager, AbstractController controller, int dir) :
        base(gameManager, controller, dir, gameManager.verticalAttackParameters.duration)
    {
    }
    
    public override void Update()
    {
        timer -= Time.deltaTime;
        if (timer > 0.00001)
        {
            // TODO
            
            base.Update();
        }
        else
        {
            SwitchState();
        }
        base.Update();
    }

    private void SwitchState()
    {
        Exit();
        switch (nextState)
        {
            case StateName.Idle:
                controller.SetState(new IdleState(gameManager, controller, Dir));
                break;
            case StateName.VerticalAttack:
                controller.SetState(new VerticalState(gameManager, controller, Dir));
                break;
            case StateName.DashAttack:
                controller.SetState(new DashState(gameManager, controller, Dir));
                break;
            case StateName.BackDash:
                controller.SetState(new BackDashState(gameManager, controller, Dir));
                break;
        }
    }

    public override StateName toS()// TODO Suppr
    {
        return StateName.VerticalAttack;
    }
    
    public override void OnVerticalAttack()
    {
        nextState = StateName.VerticalAttack;
    }

    public override void OnDashAttack()
    {
        nextState = StateName.DashAttack;
    }

    public override void OnBackDash()
    {
        nextState = StateName.BackDash;
    }
}
