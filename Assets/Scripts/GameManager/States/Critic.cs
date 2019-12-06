using UnityEngine;

public class Critic : AbstractGameState
{
    public Critic(GameManager gameManager, GameObject character) :
        base(gameManager)
    {
        gameManager.touchCooldown = gameManager.TOUCHCOOLDOWN;
        gameManager.touched = (gameManager.Controller1.characterInfo.Character == character) ? gameManager.Controller1 : gameManager.Controller2;
        gameManager.touchValue = ((gameManager.Controller1.characterInfo.Character == character ?
                           gameManager.Controller2 :
                           gameManager.Controller1).StateName == ControllerStateName.VerticalAttack) ? 2 : 1;
    }

    public override GameStateName Name()
    {
        return GameStateName.Critic;
    }

    protected override void Exit()
    {
        base.Exit();
        gameManager.touched = null;
        
        if (gameManager.roundTimer > 5 || gameManager.Controller1.points == gameManager.Controller2.points)
        {
            gameManager.SetState(new Reset(gameManager));
        }
        else
        {
            gameManager.SetState(new EndRound(gameManager));
        }
    }

    public override void Update()
    {
        base.Update();
        
        gameManager.roundTimer -= Time.deltaTime;
        gameManager.CheckDir();
        gameManager.touchCooldown -= Time.deltaTime;
        
        // Check if timer is over
        if (gameManager.touchCooldown < 0)
        {
            Kill(gameManager.touched);
            Exit();
        }
    }

    public override void Touch(GameObject character)
    {
        if (gameManager.touched.characterInfo.Character == character) return;
        
        int actualTouchValue = (((gameManager.Controller1.characterInfo.Character == character) ?
                                    gameManager.Controller2 :
                                    gameManager.Controller1).StateName == ControllerStateName.VerticalAttack) ? 2 : 1;
        
        // if both attack have same value
        if (actualTouchValue == gameManager.touchValue) { 
            Kill(gameManager.Controller1);
            Kill(gameManager.Controller2);
        }
        // if new attack value is greater than the first
        else
        {
            gameManager.touched = (gameManager.touched == gameManager.Controller1) ? gameManager.Controller2 : gameManager.Controller1;
            Kill(gameManager.touched);
        }

        Exit();
    }
    
    private void Kill(AbstractController character)
    {
        GameObject dieCharacter = character.characterInfo.Character;
        Object.Destroy(character.characterInfo.Saber.gameObject);
        
        character.characterInfo.characterAssigned = false;
        
        AbstractController killer = character == gameManager.Controller1 ? gameManager.Controller2 : gameManager.Controller1;
        ++killer.points;
        
        dieCharacter.AddComponent<Die>();
    }
}