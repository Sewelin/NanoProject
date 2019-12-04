using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consum : MonoBehaviour
{
    Renderer rend;
    Rigidbody rigid;
    public float progress;
    public float PROGRESS = 1;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rigid = GetComponent<Rigidbody>();
        progress = 0;
    }

    // Update is called once per frame
    void Update()
    {
        progress += Time.deltaTime;
        if (progress > PROGRESS) progress = 0;
        rend.material.SetFloat("_Progress", progress/PROGRESS);
        rigid.mass = 1 - (progress / PROGRESS) * 2;
        //Debug.Log(rend.material.GetFloat("Progress"));
    }
}
