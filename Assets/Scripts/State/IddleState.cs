using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IddleState
{
    protected Character character;
    protected bool direction;
    public IddleState(Character c)
    {
        this.character = c;
        direction = this.character.Direction;
        character.transform.localScale = new Vector3((character.Direction) ? 1 : -1, character.transform.localScale.y, character.transform.localScale.z);

    }
    public virtual void Move(float sens = 1) { character.state = new MoveState(character,sens); }
    public virtual void Contre() { character.state = new ContreState(character); }
    public virtual void Dash() { character.state = new DashState(character); }

    public virtual void Update() { character.rigidbody.velocity = Vector3.zero; }


    public virtual string GetName() { return "Iddle"; }
}
