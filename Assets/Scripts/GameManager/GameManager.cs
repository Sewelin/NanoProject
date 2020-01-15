using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Character models")]
    public GameObject character1Model;
    public GameObject character2Model;
    
    [Header("Animation Parameters")]
    public StateParameters verticalAttackParameters;
    public StateParameters dashAttackParameters;
    public StateParameters backDashParameters;
    public float bowDuration;
    public float battleWalkingSpeed;
    public float replaceWalkingSpeed;
    public float cineWalkingSpeed;
    
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

    [Header("Cinematic positions in scene")]
    public Transform posSpawner1;
    public Transform posSpawner2;
    public Transform posStartFight1;
    public Transform posStartFight2;
    public Transform posReposition1;
    public Transform posReposition2;
    
    [Header("Invisible Walls")]
    public GameObject leftWall;
    public GameObject rightWall;

    // Sounds
    [Header("Sounds")]
    public GameObject soundManager;
    
    // Lights
    [Header("Lights")]
    public Animator lightAnimator;

    // Timers and cooldowns
    [Header("Max timers")]
    public float TOUCHCOOLDOWN = 0.4f;
    [HideInInspector] public float touchCooldown;
    [HideInInspector] public AbstractController touched;
    [HideInInspector] public int touchValue;

    public float BACKDASHCOOLDOWN = 0.5f;
    
    public float ROUNDTIMER = 60;

    public float BUFFURINGTIMEPERCENT = 80f;
    
    [Header("User Interfaces")]
    [SerializeField] public CanvasGroup start;
    [SerializeField] public CanvasGroup pause;
    [SerializeField] public CanvasGroup join;
    [SerializeField] public CinematicMode cinematic;
    public float SPEEDFADE = 5;
    
    [Header("Bambou")]
    public RecursiveBurn[] bambou1;
    public RecursiveBurn[] bambou2;

    [HideInInspector] public Vibration vibration;
    
    [Header("Do Not Touch")]
    [SerializeField] private float roundTimer;

    public float RoundTimer {
        get => roundTimer;
        set {
            AkSoundEngine.SetRTPCValue("RTPC_Timer", value);
            roundTimer = value;
        }
    }
    


    // States
    private AbstractGameState State { get; set; }
    public GameStateName StateName => State.Name();

    private void Awake()
    {
        SetState(new SetUp(this));
        vibration = gameObject.AddComponent<Vibration>();
    }

    private void Start()
    {
        RoundTimer = ROUNDTIMER;
        vibration.StopAll();
        Cursor.lockState = CursorLockMode.None;
    }

    public GameStateName sss; // TODO suppr
    private void Update()
    {sss = StateName;
        State.Update();
    }

    public void SetState(AbstractGameState state)
    {
        State = state;
    }

    public void Pause()
    {
        if (StateName == GameStateName.SetUp) return;
        
        if (StateName == GameStateName.Pause)
        {
            Cursor.lockState = CursorLockMode.Locked;
            State.Exit();
        }
        else
        {
            SetState(new Pause(this, State));
            Cursor.lockState = CursorLockMode.None;
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
        v.x = - Controller1.dir;
        v.z = Controller1.dir;
        Controller1.characterInfo.Character.transform.localScale = v;
        
        v = Controller2.characterInfo.Character.transform.localScale;
        v.x = Controller2.dir;
        v.z = Controller2.dir;
        Controller2.characterInfo.Character.transform.localScale = v;
    }

    public void TurnOver(Transform character)
    {
        var v = character.localScale;
        v.x = - v.x;
        v.z = - v.z;
        character.localScale = v;
    }

    public void Touch(GameObject character)
    {
        State.Touch(character);
        Camera.main.GetComponent<ZoomScene>().Activate();
        cinematic.Activate();
    }

    public void CharacterInPosition(int numCharacter)
    {
        State.characterInPosition[numCharacter-1] = true;
    }
}
