using UnityEngine;

public class IdleState : AbstractState
{
    public IdleState(GameManager gameManager, AbstractController controller, int dir) :
        base(gameManager, controller, dir)
    {
    }

    public override void Update()
    {
        base.Update();
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            timer = gameManager.walkingParameters.duration;
        }
    }
    
    public override void FixedUpdate()
    {
        controller.characterInfo.RigidBody.velocity = new Vector3( movement * gameManager.walkingParameters.speed, 0f, 0f);
    }

    public override StateName toS()// TODO Suppr
    {
        return StateName.Idle;
    }
}
