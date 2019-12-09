using UnityEngine;

public class Wait : AbstractAnimation
{
    private bool _inPosition;
    
    protected override void Awake()
    {
        base.Awake();
        controller.EndDuel();
    }

    protected override void Update()
    {
        base.Update();
        if (!_inPosition && controller.StateName == ControllerStateName.Idle)
        {
            gameManager.CharacterInPosition(controller.PlayerNum);
        }
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        controller.NewDuel();
    }
}