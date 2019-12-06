using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leave : AbstractAnimation
{
    private float _direction;
    private float _speed;
    private Transform _destination;
    
    protected override void Awake()
    {
        base.Awake();
        controller.enabled = false;
        _direction = -1 * Mathf.Sign(Camera.main.transform.position.x - transform.position.x);
        _speed = gameManager.walkingSpeed;
        _destination = controller.PlayerNum == 1 ? gameManager.posSpawner1 : gameManager.posSpawner2;
        gameObject.layer = 10;
        
        // TODO Suppr color
        GetComponent<Renderer>().material.color = Color.green;
    }
    
    protected override void Update()
    {
        if (inPosition) return;
        base.Update();
        
        GetComponent<Rigidbody>().velocity = new Vector3(
            _direction * _speed,
            0f, 0f);
        if ( _direction * (transform.position.x - _destination.position.x) > 0f)
        {
            gameManager.ChararcterInPosition(controller.PlayerNum);
            inPosition = true;
        }
    }
}
