using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillState : IddleState
{
    public KillState(Character c):base(c)
    {
        c.GetComponent<Animator>().Play("Die");
        c.rigidbody.AddForce(new Vector3(0.4f * (c.Direction ? 1 : -1), 1,0)*2,ForceMode.Impulse);
    }
    public override void Move(float sens=1) { }
    public override void Contre() { }
    public override void Dash() { }

    public override void Update() { }

    public override string GetName() { return "Kill"; }
}
