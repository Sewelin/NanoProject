using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : IddleState
{
    private float time = 1;
    private float cooldown = 1;
    private float sens = 1;

    public MoveState(Character c, float sens = 1) : base(c) {
        time = character.moveOption.time;
        cooldown = character.moveOption.cooldown;
        this.sens = sens;
        
    }

    public override void Move(float sens) {}

    public override void Update()
    {
        base.Update();
        time -= Time.deltaTime;
        if (time < 0) cooldown -= Time.deltaTime;
        if(cooldown<0) character.state = new IddleState(character);

        Movement();
    }
    private void Movement()
    {
        float progress = (character.moveOption.time - time) / character.moveOption.time;
        character.rigidbody.velocity = new Vector3(sens * character.moveOption.moveCurve.Evaluate(progress) * character.moveOption.speed, 0, 0);
    }
    public override string GetName() { return (time <= 0) ? "Cooldown" : "Move"; }
}
