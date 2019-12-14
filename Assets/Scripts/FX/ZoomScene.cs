using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomScene : MonoBehaviour
{

    GameManager _gameManager;
    Vector3 _originalPos;
    Vector3 _zoomTo;
    bool _zoom;
    float _progress = 0;
    [SerializeField] private float SPEED = 0.5f;
    [SerializeField] private float TIMESPEED = 0.4f;
    [SerializeField] private AnimationCurve curve;
    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _originalPos = transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(_gameManager.StateName == GameStateName.Pause) Time.timeScale = 0;
        else { 
            if (_zoom && _progress < 1)
            {
                _progress += Time.deltaTime * SPEED;
                if (_progress > 1) _progress = 1;
            


            }
            else if (_zoom)
            {
                _zoom = false;
                _progress = 0;
            }

            AkSoundEngine.SetRTPCValue("RTPC_SlowMotion", curve.Evaluate(_progress));
            Time.timeScale = (1 - curve.Evaluate(_progress)) * TIMESPEED+ 1-TIMESPEED;
            transform.position = Vector3.Lerp(_originalPos, _zoomTo, curve.Evaluate(_progress));
        }
    }
    public void Activate()
    {
        if (!_zoom)
        {
            _zoomTo = new Vector3(Mathf.Lerp(_gameManager.Controller1.characterInfo.Character.transform.position.x, _gameManager.Controller2.characterInfo.Character.transform.position.x, 0.5f),
                _originalPos.y,
                Mathf.Lerp(_originalPos.z, _gameManager.Controller1.characterInfo.Character.transform.position.z, 0.5f));
            _zoom = true;
        }
    }
}
