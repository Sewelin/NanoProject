using UnityEngine;

public class BackDashState : AbstractControllerState
{
    private readonly int _dir;
    private static readonly int BackDash = Animator.StringToHash("BackDash");
    private static readonly int AttVerticalCut = Animator.StringToHash("AttVerticalCut");

    public BackDashState(GameManager gameManager, AbstractController controller, int dir) :
        base(gameManager, controller)
    {
        _dir = dir;
        param = gameManager.backDashParameters;
        controller.backDashCoolDown = param.Duration + 1f;
        controller.characterInfo.Animator.SetTrigger(BackDash);
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
                controller.SetState(new VerticalState(gameManager, controller, controller.dir, 0.33333f));
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
        controller.characterInfo.Animator.SetBool(AttVerticalCut, true);
        NextState = ControllerStateName.VerticalAttack;
    }

    public override void OnDashAttack()
    {
        controller.characterInfo.Animator.SetBool(AttVerticalCut, false);
        NextState = ControllerStateName.DashAttack;
    }

    public override void OnBackDash()
    {
        if (controller.backDashCoolDown > 0f) return;
        controller.characterInfo.Animator.SetBool(AttVerticalCut, false);
        NextState = ControllerStateName.BackDash;
    }

    public override void OnBow()
    {
        controller.characterInfo.Animator.SetBool(AttVerticalCut, false);
        NextState = ControllerStateName.Bow;
    }
}
