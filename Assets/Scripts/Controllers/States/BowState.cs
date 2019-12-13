using UnityEngine;
public class BowState : AbstractControllerState
{
    private readonly float _duration;
    private static readonly int Bow = Animator.StringToHash("Bow");

    public BowState(GameManager gameManager, AbstractController controller) :
        base(gameManager, controller)
    {
        _duration = gameManager.bowDuration;
        controller.characterInfo.RigidBody.velocity = Vector3.zero;
        controller.characterInfo.Animator.SetTrigger(Bow);
    }

    public override void Update()
    {
        base.Update();
        timer += Time.deltaTime;
        
        if (timer > _duration)
        {
            controller.SetState(new IdleState(gameManager, controller));
        }
    }

    /*private void SwitchState()
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
    }*/

    public override ControllerStateName Name()
    {
        return ControllerStateName.Bow;
    }
    
    // Events

    public override void OnVerticalAttack()
    {
    }

    public override void OnDashAttack()
    {
    }

    public override void OnBackDash()
    {
    }

    public override void OnBow()
    {
    }
}