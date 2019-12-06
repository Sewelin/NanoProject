using UnityEngine;

public class Die : AbstractAnimation
{
    protected override void Awake()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.position += new Vector3(0,0,0.5f);
        gameObject.layer = 10;
        
        //TODO Suppr visual effect
        GetComponent<Renderer>().material.color = Color.black;
    }
}
