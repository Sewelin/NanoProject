using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContreState : IddleState
{
    private float time = 1;
    private float cooldown = 1;
    private bool anim = false;

    public ContreState(Character c):base(c) {
        time = character.contreOption.time;
        cooldown = character.contreOption.cooldown;
    }
    public override void Move(float sens=1) { }
    public override void Contre() { }
    public override void Dash() { }

    public override void Update()
    {
        if (!anim) character.GetComponent<Animator>().Play("Cotnre");
        base.Update();
        time -= Time.deltaTime;
        if (time < 0) cooldown -= Time.deltaTime;
        if (cooldown < 0) character.state = new IddleState(character);
        anim = true;

    }

    public override string GetName() { return (time <= 0) ? "Cooldown" : "Contre"; }
}
