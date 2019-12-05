using UnityEngine;

public class DashState : AbstractAttackState
{
    public DashState(GameManager gameManager, AbstractController controller, int dir) :
        base(gameManager, controller, gameManager.dashAttackParameters, dir)
    {
    }
    

    public override StateName toS()// TODO Suppr
    {
        return StateName.DashAttack;
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
