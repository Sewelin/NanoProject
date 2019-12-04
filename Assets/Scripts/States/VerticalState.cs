using UnityEngine;

public class VerticalState : AbstractAttackState
{
    public VerticalState(GameManager gameManager, AbstractController controller, int dir) :
        base(gameManager, controller, gameManager.verticalAttackParameters, dir)
    {
    }
    
    public override void Update()
    {
        timer += Time.deltaTime;
        if (timer < param.timeSteps.x)
        {
            if (!animState.Init)
            {
                animState.Init = true;
            }
        }
        else if (timer < param.timeSteps.x + param.timeSteps.y)
        {
            if (!animState.Body)
            {
                animState.Body = true;
            }
        }
        else if (timer < param.Duration)
        {
            if (!animState.Recovery)
            {
                animState.Recovery = true;
            }
        }
        else
        {
            SwitchState();
        }

        float progress = timer / param.Duration;
        controller.characterInfo.RigidBody.velocity = new Vector3( 
            Dir * Time.deltaTime * param.speed * param.curve.Evaluate(progress), 
            0f, 0f);

        base.Update();
    }

    private void SwitchState()
    {
        Exit();
        switch (nextState)
        {
            case StateName.Idle:
                controller.SetState(new IdleState(gameManager, controller));
                break;
            case StateName.VerticalAttack:
                controller.SetState(new VerticalState(gameManager, controller, controller.dir));
                break;
            case StateName.DashAttack:
                controller.SetState(new DashState(gameManager, controller, controller.dir));
                break;
            case StateName.BackDash:
                controller.SetState(new BackDashState(gameManager, controller, controller.dir));
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
