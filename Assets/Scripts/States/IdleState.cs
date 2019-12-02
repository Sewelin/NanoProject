using UnityEngine;

public class IdleState : AbstractState
{
    public IdleState(GameManager gameManager, AbstractController controller, int dir) :
        base(gameManager, controller, dir)
    {
    }

    public override void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            timer = gameManager.walkingParameters.duration;
        }
        base.Update();
    }
    
    public override void FixedUpdate()
    {
        if (movement != 0f)
        {
            controller.characterInfo.RigidBody.velocity = new Vector3( movement * gameManager.walkingParameters.speed, 0f, 0f);
        }
        base.FixedUpdate();
    }

    public override StateName toS()// TODO Suppr
    {
        return StateName.Idle;
    }
}
