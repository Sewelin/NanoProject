using UnityEngine;

public class VerticalState : AbstractAttackState
{
    public VerticalState(GameManager gameManager, AbstractController controller, int dir) :
        base(gameManager, controller, gameManager.verticalAttackParameters, dir)
    {
    }
    

    public override StateName toS()// TODO Suppr
    {
        return StateName.VerticalAttack;
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
