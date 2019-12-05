using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractAnimation : MonoBehaviour
{
    public enum AnimationName
    {
        Leave,Die,Arrive
    }

    public AbstractController controller;
    public float Timer { get; set; }
    public float TIMER = 2;
    public bool block = false;
    // Start is called before the first frame update
    protected virtual void Awake()
    {
        controller = transform.parent.GetComponent<AbstractController>();
        if(block)controller.enabled = false;
        Timer = 0;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Timer += Time.deltaTime;
        if (Timer > TIMER) Exit();
    }
    protected virtual void Exit()
    {
        if (block) controller.enabled = true;
        DestroyImmediate(this);
    }
    public static void AddAnimation(GameObject gameObject, AnimationName name) {

        if (!gameObject.TryGetComponent<AbstractAnimation>(out AbstractAnimation actualAnimation))
        {
            if(name == AnimationName.Leave) gameObject.AddComponent<Leave>();
            else if (name == AnimationName.Arrive) gameObject.AddComponent<Arrive>();
            else gameObject.AddComponent<Die>();
        }
    }
}
