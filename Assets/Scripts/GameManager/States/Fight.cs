using UnityEngine;

public class Fight : AbstractGameState
{
    public Fight(GameManager gameManager) :
        base(gameManager)
    {
        gameManager.cinematic.Activate(false);
    }

    public override GameStateName Name()
    {
        return GameStateName.Fight;
    }

    public override void Update()
    {
        base.Update();
        
        gameManager.RoundTimer -= Time.deltaTime;
        gameManager.CheckDir();

        if (gameManager.RoundTimer < 0f && gameManager.Controller1.Points != gameManager.Controller2.Points)
        {
            gameManager.SetState(new EndRound(gameManager));
        }
    }

    public override void Touch(GameObject character)
    {
        gameManager.SetState(new Critic(gameManager, character));
    }
}