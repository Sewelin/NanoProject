using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saber : MonoBehaviour
{
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("character") 
            && (other.gameObject == gameManager.Controller1.characterInfo.Character || other.gameObject == gameManager.Controller2.characterInfo.Character))
        {
            gameManager.Touch(other.gameObject);
        }
    }
}
