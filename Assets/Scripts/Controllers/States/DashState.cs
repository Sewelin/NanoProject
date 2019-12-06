using UnityEngine;

public class DashState : AbstractAttackState
{
    public DashState(GameManager gameManager, AbstractController controller, int dir) :
        base(gameManager, controller, gameManager.dashAttackParameters, dir)
    {
    }
    

    public override ControllerStateName Name()
    {
        return ControllerStateName.DashAttack;
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
