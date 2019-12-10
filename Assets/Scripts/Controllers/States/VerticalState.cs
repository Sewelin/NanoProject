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
}
