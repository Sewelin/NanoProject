using UnityEngine;

public class Die : AbstractAnimation
{
    private static readonly int DieAnim = Animator.StringToHash("Die");
    private float timer = 20;
    private ShaderCharacterEffect shader;
    private new Rigidbody rigidbody;
    protected override void Awake()
    {
        base.Awake();
        gameObject.layer = 10;
        rigidbody = GetComponent<Rigidbody>();
        transform.position += new Vector3(0,0,0.5f);
        transform.GetComponentInChildren<Animator>().SetTrigger(DieAnim);
        controller.characterInfo.characterAssigned = false;
    }
    private void Start()
    {
        shader = GetComponent<ShaderCharacterEffect>();
    }
    protected override void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
            if(timer < 0)
            {
                shader.BeginConsum();
            }
        }
        base.Update();
        rigidbody.velocity = Vector3.zero;
        if (!inPosition)
        {
            gameManager.CharacterInPosition(controller.PlayerNum);
            inPosition = true;
        }
    }
}
