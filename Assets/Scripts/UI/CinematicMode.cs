using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicMode : MonoBehaviour
{
    private bool _active = false;
    Vector2 _origin;
    float _progress = 0;
    [SerializeField] float _speed;
    [SerializeField] RectTransform _top;
    [SerializeField] RectTransform _bottom;
    [SerializeField] AnimationCurve _curve;
    CanvasGroup canvas;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<CanvasGroup>();
        _top.sizeDelta = new Vector2(0, (Screen.height - (Screen.width * 9 / 21)) / 2);
        _bottom.sizeDelta = _top.sizeDelta;

        _top.transform.position = new Vector2(_top.transform.position.x, _top.transform.position.y + _top.sizeDelta.y);
        _bottom.transform.position = new Vector2(_bottom.transform.position.x, _bottom.transform.position.y - _bottom.sizeDelta.y);
        _origin = new Vector2(_top.transform.position.y, _bottom.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (_active && _progress < 1)
        {
            _progress += Time.deltaTime * _speed;
            if (_progress > 1) _progress = 1;
            
        }
        else if(!_active && _progress > 0)
        {
            _progress -= Time.deltaTime * _speed;
            if (_progress < 0) _progress = 0;
        }
        canvas.alpha = _progress;
        _top.transform.position = new Vector2(_top.transform.position.x, _origin.x - _top.sizeDelta.y * _curve.Evaluate(_progress));
        _bottom.transform.position = new Vector2(_bottom.transform.position.x, _origin.y + _bottom.sizeDelta.y * _curve.Evaluate(_progress));
    }
    public void Activate(bool active = true)
    {
        _active = active;
    }
}
