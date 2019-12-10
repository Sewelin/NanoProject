using UnityEngine;
public class BowState : AbstractControllerState
{
    private float _timer;
    private float _Duration;

    public BowState(GameManager gameManager, AbstractController controller) :
        base(gameManager, controller)
    {
        _Duration = gameManager.bowDuration;
        
        //TODO Suppr visual effect
        //controller.characterInfo.Character.GetComponent<Renderer>().material.color = Color.magenta;
    }

    public override void Update()
    {
        base.Update();
        _timer += Time.deltaTime;
        
        if (_timer > _Duration)
        {
            //TODO Suppr visual effect
            //controller.characterInfo.Character.GetComponent<Renderer>().material.color = Color.white;
            
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

    public override ControllerStateName Name()
    {
        return ControllerStateName.Bow;
    }
    
    // Events

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
        Exit();
        NextState = ControllerStateName.Bow;
    }
}