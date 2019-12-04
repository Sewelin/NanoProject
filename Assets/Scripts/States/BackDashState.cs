using System.Threading;
using UnityEngine;

public class BackDashState : AbstractState
{
    private int _dir;
    protected float timer;
    protected StateParameters param;
    
    public BackDashState(GameManager gameManager, AbstractController controller, int dir) :
        base(gameManager, controller)
    {
        _dir = dir;
        param = gameManager.backDashParameters;
        //TODO Suppr visual effect
        controller.characterInfo.Character.GetComponent<Renderer>().material.color = Color.blue;
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
        //TODO Suppr visual effect
        controller.characterInfo.Character.GetComponent<Renderer>().material.color = Color.white;
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
        return StateName.BackDash;
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
