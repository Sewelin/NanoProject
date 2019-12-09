using UnityEngine;

public class Die : AbstractAnimation
{
    private bool _inPosition;

    protected override void Awake()
    {
        base.Awake();
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.position += new Vector3(0,0,0.5f);
        gameObject.layer = 10;
        controller.characterInfo.characterAssigned = false;
        
        //TODO Suppr visual effect
        GetComponent<Renderer>().material.color = Color.black;
    }
    
    protected override void Update()
    {
        base.Update();
        if (!_inPosition && controller.StateName == ControllerStateName.Idle)
        {
            gameManager.CharacterInPosition(controller.PlayerNum);
        }
    }
}
