using UnityEngine;

public class DashState : AbstractAttackState
{
    public GameObject soundManager;
    private static readonly int AttDash = Animator.StringToHash("AttDash");

    public DashState(GameManager gameManager, AbstractController controller, int dir) :
        base(gameManager, controller, gameManager.dashAttackParameters, dir)
    {
        controller.characterInfo.Animator.SetTrigger(AttDash);
    }
    
    public override ControllerStateName Name()
    {
        return ControllerStateName.DashAttack;
    }
}
