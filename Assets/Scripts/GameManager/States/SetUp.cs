using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class SetUp : AbstractGameState
{
    private float joinProgress = 0;
    bool join1 = false;
    private PlayerInputManager inputManager;
    public SetUp(GameManager gameManager) :
        base(gameManager)
    {
        gameManager.cinematic.Activate(false);
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
            //gameManager.cinematic.Activate();
            joinProgress += Time.deltaTime * 5;
            if (joinProgress > 1) joinProgress = 1;
            gameManager.join.alpha = joinProgress;
        }
        if (gameManager.Controller1Assigned && !join1)
        {
            join1 = true;
            gameManager.join.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Player 2, press A to join the battlefield";
            AkSoundEngine.PostEvent("PONE_Kill_Taiko", gameManager.soundManager);
        }

        if (gameManager.Controller1Assigned && gameManager.Controller2Assigned)
        {
            gameManager.join.alpha = 0;
            AkSoundEngine.PostEvent("PTWO_Kill_Taiko", gameManager.soundManager);
            AkSoundEngine.PostEvent("Launch_Round", gameManager.soundManager);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            gameManager.SetState(new NewRound(gameManager));
        }
    }
}