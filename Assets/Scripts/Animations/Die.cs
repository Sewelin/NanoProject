using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : AbstractAnimation
{
    protected override void Awake()
    {
        TIMER = 50;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        //TODO Suppr visual effect
        GetComponent<Renderer>().material.color = Color.black;
        transform.position += new Vector3(0,0,0.1f);
    }
}
