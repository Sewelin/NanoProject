using System;
using UnityEngine;
using Object = UnityEngine.Object;

public abstract class AbstractController : MonoBehaviour
{
    // Private classes
    
    public class CharacterInfo
    {
        public bool characterAssigned;
        public Rigidbody RigidBody { get; }
        public Animator Animator { get; }
        private GameObject _character;
        public GameObject Character
        {
            get => (characterAssigned) ? _character : null;
            set => _character = value;
        }
        public Saber Saber1 { get; private set; }
        public Saber Saber2 { get; private set; }
        
        private CharacterInfo() {}

        private CharacterInfo(GameObject character)
        {
            RigidBody = character.GetComponent<Rigidbody>();
            Animator = character.GetComponentInChildren<Animator>();
            var sabers = character.transform.GetComponentsInChildren<Saber>();
            if (sabers[0].gameObject.name == "Saber1")
            {
                Saber1 = sabers[0];
                Saber2 = sabers[1];
            }
            else
            {
                Saber1 = sabers[1];
                Saber2 = sabers[0];
            }
            Character = character;
            characterAssigned = true;
        }

        public static CharacterInfo Empty()
        {
            return new CharacterInfo();
        }

        public static CharacterInfo Instantiate(GameObject playerModel, Transform transform)
        {
            return new CharacterInfo(Object.Instantiate(playerModel, transform));
        }
    }

    // Attributes
    
    [NonSerialized] public GameManager gameManager;

    public int PlayerNum { get; private set; }

    private int _points;
    public int Points {
        get => _points;
        set {
            _points = value;
            AkSoundEngine.SetRTPCValue("RTPC_DeathCount", gameManager.Controller1.Points + gameManager.Controller2.Points);
        }
    }
    public int roundWon;

    public float movement = 0;
    public int dir = 1;
    public float backDashCoolDown;
    
    public CharacterInfo characterInfo = CharacterInfo.Empty();
    protected AbstractControllerState State { get; private set; }
    public ControllerStateName StateName => State.Name();

    public bool PassivateCombatInputs { get; private set; }
    public bool replacing;

    // Methods

    protected virtual void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        
        if (!gameManager.Controller1Assigned)
        {
            PlayerNum = 1;
            gameManager.Controller1 = this;
            transform.position = gameManager.posSpawner1.position;
        }
        else
        {
            PlayerNum = 2;
            gameManager.Controller2 = this;
            transform.position = gameManager.posSpawner2.position;
        }

        PassivateCombatInputs = true;
        State = new IdleState(gameManager, this);

    }

    public void NewCharacter()
    {
        characterInfo = CharacterInfo.Instantiate(
            PlayerNum == 1 ? gameManager.character1Model : gameManager.character2Model,
            transform);
        characterInfo.Character.AddComponent<Arrive>();
        SetState(new IdleState(gameManager, this));
        gameManager.CheckDir();
    }

    public ControllerStateName sss; // TODO suppr

    protected void Update()
    {sss = StateName;
        State.Update();
    }

    protected void FixedUpdate()
    {
        State.FixedUpdate();
    }

    // Should only be used by the controller states
    public void SetState(AbstractControllerState state)
    {
        State = state;
    }

    public void EndDuel()
    {
        PassivateCombatInputs = true;
        State.ResetNextState();
    }

    public void NewDuel()
    {
        PassivateCombatInputs = false;
    }
}
