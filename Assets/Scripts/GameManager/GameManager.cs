using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject character1Model;
    public GameObject character2Model;
    public StateParameters verticalAttackParameters;
    public StateParameters dashAttackParameters;
    public StateParameters backDashParameters;
    public float walkingSpeed;
    
    // Controllers
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
    public Transform posStartFight1;
    public Transform posStartFight2;

    public float TOUCHCOOLDOWN = 0.4f;
    [NonSerialized] public float touchCooldown;
    [NonSerialized] public AbstractController touched;
    [NonSerialized] public int touchValue;
    
    public float ROUNDTIMER = 60;
    public float roundTimer;
    
    private AbstractGameState State { get; set; }
    public GameStateName StateName => State.Name();

    // Sounds
    public GameObject soundManager;

    private void Awake()
    {
        SetState(new SetUp(this));
    }

    private void Start()
    {
        roundTimer = ROUNDTIMER;
    }

    private void Update()
    {
        State.Update();
    }

    public void SetState(AbstractGameState state)
    {
        State = state;
    }

    public void Pause()
    {
        if (StateName == GameStateName.Pause)
        {
            State.Exit();
        }
        else
        {
            SetState(new Pause(this, State));
        }
    }


    public void CheckDir()
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
        State.Touch(character);
    }

    public void CharacterInPosition(int numCharacter)
    {
        State.characterInPosition[numCharacter-1] = true;
    }
}
