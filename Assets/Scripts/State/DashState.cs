using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : IddleState
{
    private float time = 1;
    private float cooldown = 1;
    private float timeStep;
    private bool anim = false;

    public DashState(Character c) : base(c) {
        time = character.dashOption.time;
        timeStep = character.moveOption.time;
        cooldown = character.dashOption.cooldown;
    }
    public override void Move(float sens=1) { }
    public override void Contre() { }
    public override void Dash() { }

    public override void Update()
    {
        base.Update();
        if (timeStep > 0)
        {
            timeStep -= Time.deltaTime;
            MovementStep();
        }
        else{
            if(!anim)character.GetComponent<Animator>().Play("Dash");
            time -= Time.deltaTime;
            if (time < 0)
            {
                cooldown -= Time.deltaTime;
            }
            else
            {
                Movement();
            }
            if (cooldown < 0) character.state = new IddleState(character);
            anim = true;
            
        }
    }

    public void Movement()
    {
        float progress = (character.dashOption.time - time) / character.dashOption.time;
        character.rigidbody.velocity = new Vector3(((direction) ? 1 : -1) * character.dashOption.moveCurve.Evaluate(progress) * character.dashOption.speed, 0, 0);
    }
    public void MovementStep()
    {
        float progress = (character.moveOption.time - timeStep) / character.moveOption.time;
        character.rigidbody.velocity = new Vector3(((direction) ? 1 : -1) * character.moveOption.moveCurve.Evaluate(progress) * character.moveOption.speed, 0, 0);
    }
    public override string GetName() { return (time<=0)?"Cooldown":"Dash"; }
}
