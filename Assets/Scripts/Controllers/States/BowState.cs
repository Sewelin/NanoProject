using UnityEngine;
public class BowState : AbstractControllerState
{
    private float _timer;
    private readonly float _duration;
    private static readonly int Bow = Animator.StringToHash("Bow");

    public BowState(GameManager gameManager, AbstractController controller) :
        base(gameManager, controller)
    {
        _duration = gameManager.bowDuration;
        
        controller.characterInfo.Animator.SetTrigger(Bow);
        //TODO Suppr visual effect
        //controller.characterInfo.Character.GetComponent<Renderer>().material.color = Color.magenta;
    }

    public override void Update()
    {
        base.Update();
        _timer += Time.deltaTime;
        
        if (_timer > _duration)
        {
            //TODO Suppr visual effect
            //controller.characterInfo.Character.GetComponent<Renderer>().material.color = Color.white;
            
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