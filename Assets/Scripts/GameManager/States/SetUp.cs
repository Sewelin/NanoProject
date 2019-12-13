using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class SetUp : AbstractGameState
{
    private float joinProgress = 0;
    private PlayerInputManager inputManager;
    public SetUp(GameManager gameManager) :
        base(gameManager)
    {
        inputManager = gameManager.GetComponent<PlayerInputManager>();
    }

    public override GameStateName Name()
    {
        return GameStateName.SetUp;
    }

    public override void Update()
    {
        base.Update();
        if(joinProgress < 1 && inputManager.enabled)
        {
            
            joinProgress += Time.deltaTime * 5;
            if (joinProgress > 1) joinProgress = 1;
            gameManager.join.alpha = joinProgress;
        }
        if (gameManager.Controller1Assigned)
        {
            gameManager.join.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Player 2, press A to join the battlefield";
        }

        if (gameManager.Controller1Assigned && gameManager.Controller2Assigned)
        {
            gameManager.join.alpha = 0;
            AkSoundEngine.PostEvent("Launch_Round", gameManager.soundManager);
            gameManager.SetState(new NewRound(gameManager));
        }
    }
}