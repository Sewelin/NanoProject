using System.Threading;
using UnityEngine;

public class BackDashState : AbstractControllerState
{
    private int _dir;
    protected float timer;
    protected StateParameters param;
    
    public BackDashState(GameManager gameManager, AbstractController controller, int dir) :
        base(gameManager, controller)
    {
        _dir = dir;
        param = gameManager.backDashParameters;
    }
    
    public override void Update()
    {
        timer += Time.deltaTime;
        if (timer < param.Duration)
        {
            float progress = timer / param.Duration;
            controller.characterInfo.RigidBody.velocity = new Vector3( 
                - _dir * param.speed * param.curve.Evaluate(progress), 
                0f, 0f);
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
            case ControllerStateName.Idle:
                controller.SetState(new IdleState(gameManager, controller));
                break;
            case ControllerStateName.VerticalAttack:
                controller.SetState(new VerticalState(gameManager, controller, controller.dir));
                break;
            case ControllerStateName.DashAttack:
                controller.SetState(new DashState(gameManager, controller, controller.dir));
                break;
            case ControllerStateName.BackDash:
                controller.SetState(new BackDashState(gameManager, controller, controller.dir));
                break;
        }
    }

    public override ControllerStateName Name()
    {
        return ControllerStateName.BackDash;
    }
    
    public override void OnVerticalAttack()
    {
        nextState = ControllerStateName.VerticalAttack;
    }

    public override void OnDashAttack()
    {
        nextState = ControllerStateName.DashAttack;
    }

    public override void OnBackDash()
    {
        nextState = ControllerStateName.BackDash;
    }
}
