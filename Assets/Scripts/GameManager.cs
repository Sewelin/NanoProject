using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject character1Model; // TODO see in editor?
    public GameObject character2Model;
    public StateParameters verticalAttackParameters; // TODO see in editor?
    public StateParameters dashAttackParameters;
    public StateParameters backDashParameters;
    public float walkingSpeed;
    public AbstractController controller1;
    public AbstractController controller2;
    public bool controller1Assigned;
    public bool controller2Assigned;

    public Transform posSpawner1;
    public Transform posSpawner2;

    public float ROUNDTIMER = 60;
    public float roundTimer;

    private float touchCooldown;
    public float TOUCHCOOLDOWN = 0.4f;
    private AbstractController touched;
    private bool touch = false;
    private float touchValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        roundTimer = ROUNDTIMER;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDir();

        // Check if one player touch the other and if timer is over
        if (touch && touchCooldown < 0)
        {
            Kill(touched);
            if (roundTimer < 0)
            {
                if (touched == controller1) controller2.characterInfo.Character.AddComponent<Leave>();
                else controller1.characterInfo.Character.AddComponent<Leave>();
            }
            touch = false;
            touched = null;

        }
        else if (touch) touchCooldown -= Time.deltaTime;
        roundTimer -= Time.deltaTime;

    }

    public void Pause()
    {// TODO check and ...
        if (Time.timeScale < 0.0001f)
        {
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0f;
        }
    }
    
    

    public void CheckDir()
    {
        if (!controller1Assigned || !controller2Assigned) return;
        if (!controller1.characterInfo.characterAssigned || !controller2.characterInfo.characterAssigned) return;

        controller1.dir = (int) Mathf.Sign(controller2.characterInfo.Character.transform.position.x -
                                           controller1.characterInfo.Character.transform.position.x);
        controller2.dir = -controller1.dir;
        
        var v = controller1.characterInfo.Character.transform.localScale;
        v.x = controller1.dir;
        controller1.characterInfo.Character.transform.localScale = v;
        
        v = controller2.characterInfo.Character.transform.localScale;
        v.x = controller2.dir;
        controller2.characterInfo.Character.transform.localScale = v;
    }

    public void Touch(GameObject character)
    {
        // if one player already touch the other
        if (touch && touched.characterInfo.Character != character)
        {
            float actualTouchValue = (((controller1.characterInfo.Character == character) ? controller2 : controller1).State.toS() == StateName.VerticalAttack) ? 2 : 1;
            // if both attack have same value
            if (actualTouchValue == touchValue) { 
                Kill(controller1);
                Kill(controller2);

                if (roundTimer < 0) NewRound();
                touch = false;
                touched = null;
            }
            // if new attack value is greater than the first
            else if(actualTouchValue > touchValue)
            {
                touched = (touched == controller1) ? controller2 : controller1;
                Kill(touched);

                if (roundTimer < 0)
                {
                    if (touched == controller1) controller2.characterInfo.Character.AddComponent<Leave>();
                    else controller1.characterInfo.Character.AddComponent<Leave>();
                }
                touch = false;
                touched = null;
            }
        }
        else
        {
            touch = true;
            touchCooldown = TOUCHCOOLDOWN;
            touched = (controller1.characterInfo.Character == character) ? controller1 : controller2;
            touchValue = (((controller1.characterInfo.Character == character) ? controller2 : controller1).State.toS() == StateName.VerticalAttack) ? 2 : 1;
        }
    }
    private void Kill(AbstractController character)
    {
        character.characterInfo.characterAssigned = false;
        character.characterInfo.Character.AddComponent<Die>();
        Destroy(character.characterInfo.Saber.gameObject);
        if(roundTimer > 0) character.New();
    }
    public void NewRound()
    {
        controller1.New();
        controller2.New();
        roundTimer = ROUNDTIMER;
    }
}
