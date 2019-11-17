using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saber : MonoBehaviour
{
    [SerializeField] private Character character;
    private bool attack = false;
    public Character otherPlayer;
    public bool saber = false;
    private string state = "";
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!state.Equals(character.state.GetName())) { 
            if((character.state.GetName() == "Contre" || character.state.GetName() == "Dash")) attack = true;
            else attack = false;
        }
        state = character.state.GetName();
        GetComponent<Collider>().enabled = attack;
        if (!attack)
        {
            if (!saber && otherPlayer != null && otherPlayer.state.GetName() != "Kill")
            {
                Debug.Log("Win");
                (Camera.main.GetComponent(typeof(GameManager)) as GameManager).Kill(otherPlayer);
            }
            saber = false;
            otherPlayer = null;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(attack && other.gameObject != character.gameObject)
        {
            if(other.tag == "Character")
                otherPlayer = other.gameObject.GetComponent(typeof(Character)) as Character;
            else if(other.tag == "Saber")
            {
                string state = character.state.GetName();
                string otherState = (other.gameObject.GetComponent(typeof(Saber)) as Saber).character.state.GetName();
                saber = state != otherState && otherState == "Contre";
            }
                
        }
    }
}
