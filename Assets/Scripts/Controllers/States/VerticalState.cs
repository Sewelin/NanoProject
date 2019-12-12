using UnityEngine;

public class VerticalState : AbstractAttackState
{
    private static readonly int AttVertical = Animator.StringToHash("AttVertical");

    public VerticalState(GameManager gameManager, AbstractController controller, int dir) :
        base(gameManager, controller, gameManager.verticalAttackParameters, dir)
    {
        controller.characterInfo.Animator.SetTrigger(AttVertical);
    }

    public override ControllerStateName Name()
    {
        return ControllerStateName.VerticalAttack;
    }
}
