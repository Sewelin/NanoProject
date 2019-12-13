using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPosition : MonoBehaviour
{
    DateTime time;

    [SerializeField] AnimationCurve _curve;
    [SerializeField] float speed = 5;
    UIController _uiController;

    int _goto;
    int _lastpos;
    float _progress;
    bool _move;

    public float Goto { get { return (_goto + 0.5f) * Screen.width; } set => _goto = (int)Mathf.Floor(value); }
    public float Lastpos { get { return (_lastpos + 0.5f) * Screen.width; } set => _lastpos = (int)Mathf.Floor(value); }

    private void Update()
    {
        if (_progress < 1 && _move)
        {
            _progress +=  (float)(DateTime.Now - time).TotalSeconds * speed;
            MoveUI();
        }
        else if (_move)
        {
            _move = false;
            _lastpos = _goto;

        }
        time = DateTime.Now;
    }
    private void Awake()
    {
        _uiController = GetComponent<UIController>();
        time = DateTime.Now;
    }

    private void MoveUI()
    {
        _uiController.GlobalPanel.position = new Vector3(
            Mathf.Lerp(Lastpos, Goto, _curve.Evaluate(_progress)), 
            _uiController.GlobalPanel.position.y, 
            _uiController.GlobalPanel.position.z
        );
    }

    public void Next(int next)
    {
        if (next != _goto)
        {
            _lastpos = _goto;
            _goto = next;
            Debug.Log("move");
            _move = true;
            _progress = 0;
        }
    }
}
