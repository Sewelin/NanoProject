using UnityEngine;

public class EndRound : AbstractGameState
{
    private readonly AbstractController _winner;
    private readonly AbstractController _looser;
    
    public EndRound(GameManager gameManager) :
        base(gameManager)
    {
        _winner = gameManager.Controller1.Points > gameManager.Controller2.Points
            ? gameManager.Controller1
            : gameManager.Controller2;
        _looser = gameManager.Controller1.Points > gameManager.Controller2.Points
            ? gameManager.Controller2
            : gameManager.Controller1;
        
        if (_winner.characterInfo.characterAssigned) _winner.characterInfo.Character.AddComponent<Leave>();
        ++_winner.roundWon;
        
        if (_looser.characterInfo.characterAssigned) _looser.characterInfo.Character.AddComponent<Die>();
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
            if (_winner.roundWon == 3 || _looser.roundWon == 3)
            {
                EndGame();
            }
            else
            {
                Object.Destroy(_winner.characterInfo.Character);
                _winner.characterInfo.characterAssigned = false;
                
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