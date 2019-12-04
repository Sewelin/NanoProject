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
        public GameObject Character { get; private set; }
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
    
    protected GameManager gameManager;

    private int _playerNum;
    
    private int _point = 0; // TODO increase
    public int dir = 1;
    public CharacterInfo characterInfo;
    public bool characterSpawned;
    protected AbstractState State { get; private set; }

    // Methods

    private void Awake()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        
        if (!gameManager.controller1Assigned)
        {
            _playerNum = 1;
            gameManager.controller1Assigned = true;
            gameManager.controller1 = this;
        }
        else
        {
            _playerNum = 2;
            gameManager.controller2Assigned = true;
            gameManager.controller2 = this;
        }
        
        
        State = new IdleState(gameManager, this);
    }

    private void Start()
    {
        characterInfo = CharacterInfo.Instantiate(
            _playerNum == 1 ? gameManager.character1Model : gameManager.character2Model,
            transform);
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
