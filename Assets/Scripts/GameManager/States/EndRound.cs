using UnityEngine;

public class EndRound : AbstractGameState
{
    private AbstractController winner;
    private AbstractController looser;
    
    public EndRound(GameManager gameManager) :
        base(gameManager)
    {
        winner = gameManager.Controller1.points > gameManager.Controller2.points
            ? gameManager.Controller1
            : gameManager.Controller2;
        looser = gameManager.Controller1.points > gameManager.Controller2.points
            ? gameManager.Controller2
            : gameManager.Controller1;
        
        if (winner.characterInfo.characterAssigned) winner.characterInfo.Character.AddComponent<Leave>();
        ++winner.roundWon;
        winner.SetState(new IdleState(gameManager, winner));
        
        if (looser.characterInfo.characterAssigned) looser.characterInfo.Character.AddComponent<Die>();
    }

    public override GameStateName Name()
    {
        return GameStateName.EndRound;
    }

    public override void Update()
    {
        base.Update();
        if (characterInPosition[0] && characterInPosition[1])
        {
            if (winner.roundWon == 3 || looser.roundWon == 3)
            {
                EndGame();
            }
            else
            {
                Object.Destroy(winner.characterInfo.Character);
                winner.characterInfo.characterAssigned = false;
                
                gameManager.SetState(new NewRound(gameManager));
            }
        }
    }

    private void EndGame()
    {
        Debug.Log("End Game");
        Application.Quit();
    }
}