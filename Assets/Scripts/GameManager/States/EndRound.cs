using UnityEngine;

public class EndRound : AbstractGameState
{
    private readonly AbstractController _winner;
    private readonly AbstractController _looser;
    
    public EndRound(GameManager gameManager) :
        base(gameManager)
    {
        gameManager.cinematic.Activate();
        _winner = gameManager.Controller1.Points > gameManager.Controller2.Points
            ? gameManager.Controller1
            : gameManager.Controller2;
        _looser = gameManager.Controller1.Points > gameManager.Controller2.Points
            ? gameManager.Controller2
            : gameManager.Controller1;
        
        ++_winner.RoundWon;


        if (_winner.characterInfo.characterAssigned)
        {
            if (_winner.RoundWon == 2 || _looser.RoundWon == 2)
            {
                _winner.characterInfo.Character.AddComponent<LeaveEnd>();
            }
            else
            {
                _winner.characterInfo.Character.AddComponent<Leave>();
            }
        }
        
        if (_looser.characterInfo.characterAssigned) _looser.characterInfo.Character.AddComponent<FallDown>();
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
            if (_winner.RoundWon == 2 || _looser.RoundWon == 2)
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
        gameManager.Pause();
    }
}