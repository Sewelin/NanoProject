using UnityEngine;

public class VerticalState : AbstractAttackState
{
    public VerticalState(GameManager gameManager, AbstractController controller, int dir) :
        base(gameManager, controller, gameManager.verticalAttackParameters, dir)
    {
    }
    

    public override ControllerStateName Name()
    {
        return ControllerStateName.VerticalAttack;
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
