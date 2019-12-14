using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveEnd : AbstractAnimation
{
    private int _direction;
    private float _speed;
    private Transform _destination;
    private bool _turned;
    private bool _hasBowed;
    private static readonly int WalkCineIn = Animator.StringToHash("WalkCineIn");
    private static readonly int WalkCineOut = Animator.StringToHash("WalkCineOut");

    protected override void Awake()
    {
        base.Awake();
        controller.EndDuel();
        _speed = gameManager.cineWalkingSpeed;
        _destination = controller.PlayerNum == 1 ? gameManager.posSpawner1 : gameManager.posSpawner2;
        _direction = Direction();
        gameObject.layer = 10;
    }
    
    protected override void Update()
    {
        if (inPosition || controller.StateName != ControllerStateName.Idle) return;
        base.Update();

        if (!_hasBowed)
        {
            gameManager.cinematic.End();
            controller.SetState(new BowState(gameManager, controller));
            _hasBowed = true;
            return;
        }

        if (!_turned)
        {
            //gameManager.TurnOver(transform);
            controller.characterInfo.Animator.SetTrigger(WalkCineIn);
            _turned = true;
        }
        
        GetComponent<Rigidbody>().velocity = new Vector3(
            _direction * _speed,
            0f, 0f);
        if ( Direction() != _direction)
        {
            controller.characterInfo.Animator.SetTrigger(WalkCineOut);
            gameManager.CharacterInPosition(controller.PlayerNum);
            inPosition = true;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    private int Direction()
    {
        return (int) Mathf.Sign(transform.position.x - _destination.position.x);
    }
}
