public class Pause : AbstractGameState
{
    public Pause(GameManager gameManager) :
        base(gameManager)
    {// TODO
    }

    public override GameStateName Name()
    {
        return GameStateName.Pause;
    }
}