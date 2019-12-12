using System;
using UnityEngine;

public class VerticalState : AbstractAttackState
{
    private static readonly int AttVertical = Animator.StringToHash("AttVertical");
    private static readonly int AttVerticalCut = Animator.StringToHash("AttVerticalCut");

    public VerticalState(GameManager gameManager, AbstractController controller, int dir, float initTimer = 0f) :
        base(gameManager, controller, gameManager.verticalAttackParameters, dir)
    {
        if (initTimer < 0.0001)
        {
            controller.characterInfo.Animator.SetTrigger(AttVertical);
        }
    }

    public override ControllerStateName Name()
    {
        return ControllerStateName.VerticalAttack;
    }

    protected override void Exit()
    {
        base.Exit();
        controller.characterInfo.Animator.SetBool(AttVerticalCut, false);
    }
}
