using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject character1Model; // TODO see in editor?
    public GameObject character2Model;
    public StateParameters verticalAttackParameters; // TODO see in editor?
    public StateParameters dashAttackParameters;
    public StateParameters backDashParameters;
    public float walkingSpeed;
    private AbstractController _controller1;
    private AbstractController _controller2;
    public bool Controller1Assigned { get; private set; }
    public bool Controller2Assigned { get; private set; }
    public AbstractController Controller1
    {
        get => _controller1;
        set
        {
            Controller1Assigned = true;
            _controller1 = value;
        }
    }
    public AbstractController Controller2
    {
        get => _controller2;
        set
        {
            Controller2Assigned = true;
            _controller2 = value;
        }
    }

    public Transform posSpawner1;
    public Transform posSpawner2;

    public float ROUNDTIMER = 60;
    public float roundTimer;

    private float _touchCooldown;
    public float TOUCHCOOLDOWN = 0.4f;
    private AbstractController _touched;
    private bool _touch;
    private int _touchValue;

    // Start is called before the first frame update
    private void Start()
    {
        roundTimer = ROUNDTIMER;
    }

    // Update is called once per frame
    private void Update()
    {
        CheckDir();

        // Check if one player touch the other and if timer is over
        if (_touch && _touchCooldown < 0)
        {
            Kill(_touched);
            if (roundTimer < 0)
            {
                GameObject addAnim;
                addAnim = _touched == Controller1 ? Controller2.characterInfo.Character : Controller1.characterInfo.Character;
                AbstractAnimation.AddAnimation(addAnim, AbstractAnimation.AnimationName.Leave);
            }
            _touch = false;
            _touched = null;

        }
        else if (_touch) _touchCooldown -= Time.deltaTime;
        roundTimer -= Time.deltaTime;

    }

    public void Pause()
    {
        // TODO check and ...
        Time.timeScale = Time.timeScale < 0.0001f ? 1f : 0f;
    }


    private void CheckDir()
    {
        if (!Controller1Assigned || !Controller2Assigned) return;
        if (!Controller1.characterInfo.characterAssigned || !Controller2.characterInfo.characterAssigned) return;

        Controller1.dir = (int) Mathf.Sign(Controller2.characterInfo.Character.transform.position.x -
                                           Controller1.characterInfo.Character.transform.position.x);
        Controller2.dir = -Controller1.dir;
        
        var v = Controller1.characterInfo.Character.transform.localScale;
        v.x = Controller1.dir;
        Controller1.characterInfo.Character.transform.localScale = v;
        
        v = Controller2.characterInfo.Character.transform.localScale;
        v.x = Controller2.dir;
        Controller2.characterInfo.Character.transform.localScale = v;
    }

    public void Touch(GameObject character)
    {
        // if one player already touch the other
        if (_touch && _touched.characterInfo.Character != character)
        {
            int actualTouchValue = (((Controller1.characterInfo.Character == character) ? Controller2 : Controller1).State.toS() == StateName.VerticalAttack) ? 2 : 1;
            // if both attack have same value
            if (actualTouchValue == _touchValue) { 
                Kill(Controller1);
                Kill(Controller2);

                if (roundTimer < 0) NewRound();
                _touch = false;
                _touched = null;
            }
            // if new attack value is greater than the first
            else if(actualTouchValue > _touchValue)
            {
                _touched = (_touched == Controller1) ? Controller2 : Controller1;
                Kill(_touched);

                if (roundTimer < 0)
                {
                    GameObject addAnim;
                    if (_touched == Controller1) addAnim = Controller2.characterInfo.Character;
                    else addAnim = Controller1.characterInfo.Character;
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
            _touched = (Controller1.characterInfo.Character == character) ? Controller1 : Controller2;
            _touchValue = (((Controller1.characterInfo.Character == character) ? Controller2 : Controller1).State.toS() == StateName.VerticalAttack) ? 2 : 1;
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
        Controller1.New();
        Controller2.New();
        roundTimer = ROUNDTIMER;
    }
}
