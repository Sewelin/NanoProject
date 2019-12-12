using UnityEngine;

public class IdleState : AbstractControllerState
{
    private static readonly int WalkingSpeed = Animator.StringToHash("WalkingSpeed");

    public IdleState(GameManager gameManager, AbstractController controller) :
        base(gameManager, controller)
    {
    }

    ~IdleState()
    {
        controller.movement = 0f;
        controller.characterInfo.RigidBody.velocity = Vector3.zero;
    }
    
    public override void FixedUpdate()
    {
        if (controller.PassivateCombatInputs || !controller.characterInfo.characterAssigned || controller.replacing) return;
        controller.characterInfo.RigidBody.velocity = new Vector3( controller.movement * gameManager.walkingSpeed, 0f, 0f);
        controller.characterInfo.Animator.SetFloat(WalkingSpeed, controller.dir * controller.movement * gameManager.walkingSpeed);
    }

    public override ControllerStateName Name()
    {
        return ControllerStateName.Idle;
    }
}
