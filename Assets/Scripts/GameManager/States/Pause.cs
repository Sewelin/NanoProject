using UnityEngine;

public class Pause : AbstractGameState
{
    private readonly AbstractGameState _previousState;
    
    
    public Pause(GameManager gameManager, AbstractGameState previousState) :
        base(gameManager)
    {
        Time.timeScale = 0f;
        _previousState = previousState;
        Debug.Log("Pause");

        AkSoundEngine.PostEvent("Menu_Pause", gameManager.soundManager);
        gameManager.pause.GetComponent<UIController>().Resume(true);
    }

    public override GameStateName Name()
    {
        return GameStateName.Pause;
    }
    public override void Update()
    {
        base.Update();

    }

    public override void Exit()
    {
        base.Exit();
        gameManager.pause.GetComponent<UIController>().Resume(false);
        gameManager.SetState(_previousState);
        Time.timeScale = 1f;

        AkSoundEngine.PostEvent("Menu_Continue", gameManager.soundManager);
    }
}