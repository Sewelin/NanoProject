using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractAnimation : MonoBehaviour
{
    public enum AnimationName
    {
        Leave,Die,Arrive
    }

    protected GameManager gameManager;
    public AbstractController controller;
    protected bool inPosition = false;
    
    protected virtual void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        controller = transform.parent.GetComponent<AbstractController>();
    }

    protected virtual void Update()
    {
    }
    
    protected virtual void OnDestroy()
    {
    }
}
