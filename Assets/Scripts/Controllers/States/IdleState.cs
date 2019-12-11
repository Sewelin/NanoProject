using UnityEngine;

public class IdleState : AbstractControllerState
{
    private static readonly int WalkingSpeed = Animator.StringToHash("WalkingSpeed");

    public IdleState(GameManager gameManager, AbstractController controller) :
        base(gameManager, controller)
    {
    }
    
    public override void FixedUpdate()
    {
        if (controller.PassivateCombatInputs) return;
        controller.characterInfo.RigidBody.velocity = new Vector3( controller.movement * gameManager.walkingSpeed, 0f, 0f);
        controller.characterInfo.Animator.SetFloat(WalkingSpeed, controller.dir * controller.movement * gameManager.walkingSpeed);
    }

    public override ControllerStateName Name()
    {
        return ControllerStateName.Idle;
    }
}
