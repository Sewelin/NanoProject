using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyTexture : MonoBehaviour
{
    [SerializeField] Texture texture;
    [SerializeField] Texture normal;

    private void Awake()
    {
        GetComponent<Renderer>().material.SetTexture("_Texture", texture);
        GetComponent<Renderer>().material.SetTexture("_Normal", normal);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
