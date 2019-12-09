using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leave : AbstractAnimation
{
    private Vector3 goTo;
    private float speed = 1;
    protected override void Awake()
    {
        controller = transform.parent.GetComponent<AbstractController>();
        goTo = (controller.PlayerNum == 1) ? controller.gameManager.posSpawner1.transform.position : controller.gameManager.posSpawner2.transform.position;
        controller.enabled = false;
        GetComponent<Rigidbody>().velocity = new Vector3(Mathf.Sign(goTo.x - transform.position.x) * speed, 0, 0);
        gameObject.layer = 10;
        Debug.Log(goTo);
        GetComponent<Renderer>().material.color = Color.green;
    }
    protected override void Update()
    {
        if ((controller.PlayerNum == 1 && transform.position.x < goTo.x) || (controller.PlayerNum == 2 && transform.position.x > goTo.x)) Exit();
        GetComponent<Rigidbody>().velocity = new Vector3(Mathf.Sign(goTo.x - transform.position.x) * speed, 0, 0);
    }
    protected override void Exit()
    {
        Destroy(this.gameObject);
        controller.gameManager.NewRound();
        base.Exit();
    }
}
