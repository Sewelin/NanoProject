using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replace : AbstractAnimation
{
    private int _direction;
    private float _speed;
    private Transform _destination;
    
    protected override void Awake()
    {
        base.Awake();
        controller.EndDuel();
        _speed = gameManager.walkingSpeed;
        _destination = controller.PlayerNum == 1 ? gameManager.posReposition1 : gameManager.posReposition2;
        _direction = Direction();
    }

    protected override void Update()
    {
        if (inPosition || controller.StateName != ControllerStateName.Idle) return;
        base.Update();
        
        GetComponent<Rigidbody>().velocity = new Vector3(
            _direction * _speed,
            0f, 0f);
        if ( Direction() != _direction)
        {
            gameManager.CharacterInPosition(controller.PlayerNum);
            inPosition = true;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        controller.movement = 0f;
        controller.NewDuel();
    }

    private int Direction()
    {
        return (int) Mathf.Sign(_destination.position.x - transform.position.x);
    }
}
