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

    private float _touchCooldown;
    public float TOUCHCOOLDOWN = 0.4f;
    private AbstractController _touched;
    private bool _touch = false;
    private float _touchValue = 0;

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
        if (_touch && _touchCooldown < 0)
        {
            Kill(_touched);
            if (roundTimer < 0)
            {
                GameObject addAnim;
                if (_touched == controller1) addAnim = controller2.characterInfo.Character;
                else addAnim = controller1.characterInfo.Character;
                AbstractAnimation.AddAnimation(addAnim, AbstractAnimation.AnimationName.Leave);
            }
            _touch = false;
            _touched = null;

        }
        else if (_touch) _touchCooldown -= Time.deltaTime;
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
        if (_touch && _touched.characterInfo.Character != character)
        {
            float actualTouchValue = (((controller1.characterInfo.Character == character) ? controller2 : controller1).State.toS() == StateName.VerticalAttack) ? 2 : 1;
            // if both attack have same value
            if (actualTouchValue == _touchValue) { 
                Kill(controller1);
                Kill(controller2);

                if (roundTimer < 0) NewRound();
                _touch = false;
                _touched = null;
            }
            // if new attack value is greater than the first
            else if(actualTouchValue > _touchValue)
            {
                _touched = (_touched == controller1) ? controller2 : controller1;
                Kill(_touched);

                if (roundTimer < 0)
                {
                    GameObject addAnim;
                    if (_touched == controller1) addAnim = controller2.characterInfo.Character;
                    else addAnim = controller1.characterInfo.Character;
                    AbstractAnimation.AddAnimation(addAnim, AbstractAnimation.AnimationName.Leave);
                }
                _touch = false;
                _touched = null;
            }
        }
        else
        {
            _touch = true;
            _touchCooldown = TOUCHCOOLDOWN;
            _touched = (controller1.characterInfo.Character == character) ? controller1 : controller2;
            _touchValue = (((controller1.characterInfo.Character == character) ? controller2 : controller1).State.toS() == StateName.VerticalAttack) ? 2 : 1;
        }
    }
    private void Kill(AbstractController character)
    {
        GameObject dieCharacter = character.characterInfo.Character;
        Destroy(character.characterInfo.Saber.gameObject);
        character.characterInfo.characterAssigned = false;
        if (roundTimer > 0) character.New();
        else
        {
            character.characterInfo.characterAssigned = false ;
        }
        
        AbstractAnimation.AddAnimation(dieCharacter, AbstractAnimation.AnimationName.Die);
        
        
    }
    public void NewRound()
    {
        controller1.New();
        controller2.New();
        roundTimer = ROUNDTIMER;
    }
}
