using UnityEngine;

public abstract class AbstractGameState
{
    protected readonly GameManager gameManager;
    public bool[] characterInPosition = new bool[2];

    // Methods
    protected AbstractGameState(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    public abstract GameStateName Name();

    public virtual void Update()
    {
    }

    public virtual void Exit()
    {
    }

    public virtual void Touch(GameObject character)
    {
    }
}