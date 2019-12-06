using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToStart : AbstractAnimation
{
    private float _direction;
    private float _speed;
    private Transform _destination;
    
    protected override void Awake()
    {
        base.Awake();
        controller.enabled = false;
        _speed = gameManager.walkingSpeed;
        _destination = controller.PlayerNum == 1 ? gameManager.posStartFight1 : gameManager.posStartFight2;
        _direction = Mathf.Sign(_destination.position.x - transform.position.x);
    }

    protected override void Update()
    {
        if (inPosition) return;
        base.Update();
        
        GetComponent<Rigidbody>().velocity = new Vector3(
            _direction * _speed,
            0f, 0f);
        if ( Mathf.Abs(transform.position.x - _destination.position.x) < 0.01)
        {
            gameManager.ChararcterInPosition(controller.PlayerNum);
            inPosition = true;
        }
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        controller.enabled = true;
    }
}
