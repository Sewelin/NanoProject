using UnityEngine;

public class Wait : AbstractAnimation
{
    private bool _inPosition;
    
    protected override void Awake()
    {
        base.Awake();
        controller.enabled = false;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    protected override void Update()
    {
        base.Update();
        if (!_inPosition)
        {
            gameManager.CharacterInPosition(controller.PlayerNum);
        }
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        controller.enabled = true;
    }
}