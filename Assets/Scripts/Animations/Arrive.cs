using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrive : AbstractAnimation
{
    private float direction;
    private float speed = 1;
    protected override void Awake()
    {
        
        block = true;
        base.Awake();
        controller.SetState(new IdleState(controller.gameManager, controller));
        TIMER = 5;
        
        direction = Mathf.Sign(Camera.main.transform.position.x - transform.position.x);
    }

    protected override void Update()
    {
        base.Update();

        GetComponent<Rigidbody>().velocity = new Vector3(
            direction * speed,
            0f, 0f);

    }
    protected override void Exit()
    {
        
        base.Exit();
    }
}
