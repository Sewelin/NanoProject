using UnityEngine;

public class Pause : AbstractGameState
{
    private readonly AbstractGameState _previousState;
    
    public Pause(GameManager gameManager, AbstractGameState previousState) :
        base(gameManager)
    {
        Time.timeScale = 0f;
        _previousState = previousState;

        AkSoundEngine.PostEvent("Menu_Pause", gameManager.soundManager);
    }

    public override GameStateName Name()
    {
        return GameStateName.Pause;
    }

    public override void Exit()
    {
        base.Exit();
        
        gameManager.SetState(_previousState);
        Time.timeScale = 1f;

        AkSoundEngine.PostEvent("Menu_Continue", gameManager.soundManager);
    }
}