using UnityEngine;

public class Die : AbstractAnimation
{
    private bool _inPosition;
    private static readonly int DieAnim = Animator.StringToHash("Die");

    protected override void Awake()
    {
        base.Awake();
        gameObject.layer = 10;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.position += new Vector3(0,0,0.5f);
        transform.GetComponentInChildren<Animator>().SetTrigger(DieAnim);

        //TODO Suppr visual effect
        //GetComponent<Renderer>().material.color = Color.black;
    }

    protected override void Update()
    {
        base.Update();

        if (!inPosition)
        {
            gameManager.CharacterInPosition(controller.PlayerNum);
        }
    }
}
