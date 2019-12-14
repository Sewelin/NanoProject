using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBlood : MonoBehaviour
{
    [SerializeField] ParticleSystem blood;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Blood()
    {
        blood.Play();
    }
}
