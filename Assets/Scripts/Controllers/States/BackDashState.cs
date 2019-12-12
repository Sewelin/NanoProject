using UnityEngine;

public class BackDashState : AbstractControllerState
{
    private readonly int _dir;
    private float _timer;
    private StateParameters _param;
    private static readonly int BackDash = Animator.StringToHash("BackDash");

    public BackDashState(GameManager gameManager, AbstractController controller, int dir) :
        base(gameManager, controller)
    {
        _dir = dir;
        _param = gameManager.backDashParameters;
        controller.backDashCoolDown = _param.Duration + 1f;
        controller.characterInfo.Animator.SetTrigger(BackDash);
    }
    
    public override void Update()
    {
        base.Update();
        _timer += Time.deltaTime;
        
        if (_timer < _param.Duration)
        {
            float progress = _timer / _param.Duration;
            controller.characterInfo.RigidBody.velocity = new Vector3( 
                - _dir * _param.speed * _param.curve.Evaluate(progress), 
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
