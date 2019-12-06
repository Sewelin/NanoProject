using UnityEngine;

public class Fight : AbstractGameState
{
    public Fight(GameManager gameManager) :
        base(gameManager)
    {
    }

    public override GameStateName Name()
    {
        return GameStateName.Fight;
    }

    public override void Update()
    {
        base.Update();
        
        gameManager.roundTimer -= Time.deltaTime;
        gameManager.CheckDir();
    }

    public override void Touch(GameObject character)
    {
        gameManager.SetState(new Critic(gameManager, character));
    }
}