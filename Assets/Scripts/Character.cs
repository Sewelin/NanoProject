using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Character : MonoBehaviour
{
    public Rigidbody rigidbody;
    public Saber saber;
    [SerializeField] private bool player = true;
    private bool direction = true;
    public bool Direction { get => direction; set => direction = value; }

    public IddleState state;


    [SerializeField] private TextMeshPro stateInfo;
    [SerializeField] private float speed = 1;

    [SerializeField] public StateInfo moveOption;
    [SerializeField] public StateInfo dashOption;
    [SerializeField] public StateInfo contreOption;

    public KeyCode left;
    public KeyCode right;
    public KeyCode dash;
    public KeyCode contre;




    // Start is called before the first frame update
    void Start()
    {
        direction = player;
        rigidbody = GetComponent<Rigidbody>();
        state = new IddleState(this);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(direction != GetDirection() && (state.GetName() == "Iddle" || state.GetName() == "Move"))
        {
            this.transform.localScale = new Vector3(-this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
            direction = !direction;
        }*/
        
        state.Update(); 
        if (Input.GetKeyDown(dash)) state.Dash();
        else if (Input.GetKeyDown(contre)) state.Contre();
        else if (Input.GetKey(left)) state.Move(-1);
        else if (Input.GetKey(right)) state.Move(1);
    }
    bool GetDirection()
    {
        if (Input.GetKey(right)) return true;
        else if (Input.GetKey(left)) return false;
        return direction;
    }
    public void Kill()
    {
        state = new KillState(this);
    }
    
}
