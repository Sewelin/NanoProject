public class SetUp : AbstractGameState
{
    public SetUp(GameManager gameManager) :
        base(gameManager)
    {

    }

    public override GameStateName Name()
    {
        return GameStateName.SetUp;
    }

    public override void Update()
    {
        base.Update();
        if (gameManager.Controller1Assigned && gameManager.Controller2Assigned)
        {
            AkSoundEngine.PostEvent("Launch_Round", gameManager.soundManager);
            gameManager.SetState(new NewRound(gameManager));
        }
    }
}