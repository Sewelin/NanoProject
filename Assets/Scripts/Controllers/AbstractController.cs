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
        public Saber Saber { get; private set; }
        
        private CharacterInfo() {}

        private CharacterInfo(GameObject character)
        {
            RigidBody = character.GetComponent<Rigidbody>();
            Animator = character.GetComponent<Animator>();
            Saber = character.transform.GetChild(0).GetComponent<Saber>();
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
    
    public GameManager gameManager;

    public int PlayerNum { get; private set; }

    public float movement = 0;
    public int dir = 1;
    public CharacterInfo characterInfo = CharacterInfo.Empty();
    public AbstractState State { get; private set; }
   

    // Methods

    private void Awake()
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

        State = new IdleState(gameManager, this);

    }

    private void Start()
    {
        New();
        
        
    }
    public void New()
    {
        characterInfo = CharacterInfo.Instantiate(
            PlayerNum == 1 ? gameManager.character1Model : gameManager.character2Model,
            transform);
        AbstractAnimation.AddAnimation(characterInfo.Character, AbstractAnimation.AnimationName.Arrive);
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
