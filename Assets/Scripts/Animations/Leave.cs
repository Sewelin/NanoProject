using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leave : AbstractAnimation
{
    protected override void Awake()
    {
        controller = transform.parent.GetComponent<AbstractController>();
        if (block) controller.enabled = false;
        Timer = 0;
    }
    protected override void Update()
    {
        if (Timer > TIMER) Exit();
    }
}
