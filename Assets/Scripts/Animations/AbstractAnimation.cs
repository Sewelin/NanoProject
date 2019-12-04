using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractAnimation : MonoBehaviour
{
    AbstractController controller;
    public float Timer { get; set; }
    public float TIMER;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        controller = transform.parent.GetComponent<AbstractController>();
        controller.enabled = false;
        Timer = 0;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Timer += Time.deltaTime;
        if (Timer > TIMER) Exit();
    }
    protected void Exit()
    {
        controller.enabled = true;
        Destroy(this);
    }
}
