using UnityEngine;

public class IdleState : AbstractControllerState
{
    public IdleState(GameManager gameManager, AbstractController controller) :
        base(gameManager, controller)
    {
    }

    public override void Update()
    {
        base.Update();

    }
    
    public override void FixedUpdate()
    {
        controller.characterInfo.RigidBody.velocity = new Vector3( controller.movement * gameManager.walkingSpeed, 0f, 0f);
    }

    public override ControllerStateName Name()
    {
        return ControllerStateName.Idle;
    }
}
