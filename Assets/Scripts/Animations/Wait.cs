using UnityEngine;

public class Wait : AbstractAnimation
{
    protected override void Awake()
    {
        controller.enabled = false;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameManager.CharacterInPosition(controller.PlayerNum);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        controller.enabled = true;
    }
}