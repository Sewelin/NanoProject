using System;
using UnityEngine;
using Object = UnityEngine.Object;

public abstract class AbstractController : MonoBehaviour
{
    // Private classes
    
    public class CharacterInfo
    {
        public bool characterAssigned;
        public Rigidbody RigidBody { get; private set; }
        public Animator Animator { get; private set; }
        private GameObject _character;
        public GameObject Character { get { return (characterAssigned) ? _character : null; } set => _character = value; }
        public Saber Saber { get; private set; }

        private CharacterInfo(GameObject character)
        {
            RigidBody = character.GetComponent<Rigidbody>();
            Animator = character.GetComponent<Animator>();
            Saber = character.transform.GetChild(0).GetComponent<Saber>();
            Character = character;
            characterAssigned = true;
        }

        public static CharacterInfo Instantiate(GameObject playerModel, Transform transform)
        {
            return new CharacterInfo(Object.Instantiate(playerModel, transform));
        }
    }

    // Attributes
    
    public GameManager gameManager;

    private int _playerNum;
    public int PlayerNum { get => _playerNum; }

    private int _point = 0; // TODO increase
    public float movement = 0;
    public int dir = 1;
    public CharacterInfo characterInfo;
    public bool characterSpawned;
    public AbstractState State { get; private set; }
   

    // Methods

    private void Awake()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        
        if (!gameManager.controller1Assigned)
        {
            _playerNum = 1;
            gameManager.controller1Assigned = true;
            gameManager.controller1 = this;
            transform.position = gameManager.posSpawner1.position;
        }
        else
        {
            _playerNum = 2;
            gameManager.controller2Assigned = true;
            gameManager.controller2 = this;
            transform.position = gameManager.posSpawner2.position;
        }

        State = new IdleState(gameManager, this);

    }

    private void Start()
    {
        New();
        
        
    }
    public void New()
    {
        characterInfo = CharacterInfo.Instantiate(
            _playerNum == 1 ? gameManager.character1Model : gameManager.character2Model,
            transform);
        AbstractAnimation.AddAnimation(characterInfo.Character, AbstractAnimation.AnimationName.Arrive);
        characterSpawned = true;
    }

    public StateName s; // TODO Suppr
    protected void Update()
    {
        s = State.toS();// TODO Suppr
        State.Update();
    }

    protected void FixedUpdate()
    {
        State.FixedUpdate();
    }

    public void SetState(AbstractState state)
    {
        State = state;
    }
}
