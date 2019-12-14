using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecursiveBurn : MonoBehaviour
{
    float _progress = 0;
    Material _shader;
    [SerializeField] RecursiveBurn _next;
    bool _start;

    private void Awake()
    {
        _shader = GetComponent<Renderer>().material;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_start && _progress < 1) { 
            _progress += Time.deltaTime * 0.2f;
            if(_progress > 0.3f)
            {

                if (_next != null) _next.Launch();
            }
            _shader.SetFloat("_Progress", _progress);
        }
    }
    public void Launch()
    {
        _start = true;
    }
}
