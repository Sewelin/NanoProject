using UnityEngine;

public class AnimSoundManager : MonoBehaviour
{
    public AkEvent dash;
    public AkEvent vertical;
    public AkEvent backward_jump;
    public AkEvent bow;
    public AkEvent death;
    public AkEvent forward_prez;
    public AkEvent forward_step;
    //public AkEvent backward;
    public AkEvent idle;
    public AkEvent consume;


    public void SFX_Dash()
    {
        dash.HandleEvent(gameObject);
    }

    public void SFX_VerticalAttack()
    {
        vertical.HandleEvent(gameObject);
    }

    public void SFX_Backward_Jump()
    {
        backward_jump.HandleEvent(gameObject);
    }

    public void SFX_Bow()
    {
        bow.HandleEvent(gameObject);
    }

    public void SFX_Death()
    {
        death.HandleEvent(gameObject);
    }

    public void SFX_Forward_prez()
    {
        forward_prez.HandleEvent(gameObject);
    }

    public void SFX_Forward_step()
    {
        forward_step.HandleEvent(gameObject);
    }

    public void SFX_Idle()
    {
        idle.HandleEvent(gameObject);
    }

    public void SFX_Consume()
    {
        consume.HandleEvent(gameObject);
    }

}
