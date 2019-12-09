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
        controller.backDashCoolDown = param.Duration + 1f;
    }
    
    public override void Update()
    {
        base.Update();
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
    }

    private void SwitchState()
    {
        Exit();
        switch (NextState)
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
            case ControllerStateName.Bow:
                controller.SetState(new BowState(gameManager, controller));
                break;
        }
    }

    protected override void Exit()
    {
        base.Exit();
        controller.backDashCoolDown = gameManager.BACKDASHCOOLDOWN;
    }

    public override ControllerStateName Name()
    {
        return ControllerStateName.BackDash;
    }
    
    public override void OnVerticalAttack()
    {
        NextState = ControllerStateName.VerticalAttack;
    }

    public override void OnDashAttack()
    {
        NextState = ControllerStateName.DashAttack;
    }

    public override void OnBackDash()
    {
        NextState = ControllerStateName.BackDash;
    }

    public override void OnBow()
    {
        NextState = ControllerStateName.Bow;
    }
}
