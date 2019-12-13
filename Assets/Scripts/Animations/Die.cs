﻿using UnityEngine;

public class Die : AbstractAnimation
{
    private static readonly int DieAnim = Animator.StringToHash("Die");
    private Rigidbody rigidbody;
    protected override void Awake()
    {
        base.Awake();
        controller.EndDuel();
        gameObject.layer = 10;
        rigidbody = GetComponent<Rigidbody>();
        transform.position += new Vector3(0,0,0.5f);
        transform.GetComponentInChildren<Animator>().SetTrigger(DieAnim);
        controller.characterInfo.characterAssigned = false;
    }
    private void Start()
    {
    }
    protected override void Update()
    {
        base.Update();
        rigidbody.velocity = Vector3.zero;
        if (!inPosition)
        {
            gameManager.CharacterInPosition(controller.PlayerNum);
            inPosition = true;
        }
    }
}
