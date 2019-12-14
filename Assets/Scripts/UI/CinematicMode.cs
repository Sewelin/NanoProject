using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CinematicMode : MonoBehaviour
{
    DateTime time;

    [SerializeField] private bool _end = false;
    [SerializeField] private Image image;
    Vector2 _origin;
    float _originSize;
    float _progress = 0;
    [SerializeField] float _speed;
    [SerializeField] RectTransform _top;
    [SerializeField] RectTransform _bottom;
    [SerializeField] AnimationCurve _curve;
    [SerializeField] AnimationCurve _curveAlpha;
    [SerializeField] AnimationCurve _endCurve;
    CanvasGroup canvas;

    private bool _active = false;
    [SerializeField] float endPercentTop = 0.4f;
    [SerializeField] float endPercentBottom = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<CanvasGroup>();
        _originSize = (Screen.height - (Screen.width * 9 / 21)) / 2;
        _top.sizeDelta = new Vector2(0, _originSize);
        _bottom.sizeDelta = _top.sizeDelta;

        _top.transform.position = new Vector2(_top.transform.position.x, _top.transform.position.y + _top.sizeDelta.y);
        _bottom.transform.position = new Vector2(_bottom.transform.position.x, _bottom.transform.position.y - _bottom.sizeDelta.y);
        _origin = new Vector2(_top.transform.position.y, _bottom.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (_active && _progress < 1 || _end)
        {
            _progress += (float)(DateTime.Now - time).TotalSeconds * _speed;
            if (_progress > 1 && !_end) _progress = 1;
            
        }
        else if(!_active && _progress > 0)
        {
            _progress -= (float)(DateTime.Now - time).TotalSeconds * _speed;
            if (_progress < 0) _progress = 0;
        }
        canvas.alpha = _curveAlpha.Evaluate(_progress);

        if (_end)
        {
            _top.sizeDelta = new Vector2(0, Mathf.Lerp(_originSize, Screen.height * (endPercentTop) , _curve.Evaluate(_progress)));
            _bottom.sizeDelta = new Vector2(0, Mathf.Lerp(_originSize, Screen.height * (endPercentBottom), _curve.Evaluate(_progress)));
            image.color = new Color(1, 1, 1, _endCurve.Evaluate(_progress));
        }
        _top.transform.position = new Vector2(_top.transform.position.x, _origin.x - _originSize * _curve.Evaluate(_progress));
        _bottom.transform.position = new Vector2(_bottom.transform.position.x, _origin.y + _originSize * _curve.Evaluate(_progress));
        time = DateTime.Now;
    }
    public void Activate(bool active = true)
    {
        _active = active;
    }
}
