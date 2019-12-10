using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    RectTransform _rect;
    [SerializeField] RectTransform _globalPanel;

    int _goto;
    int _lastpos;
    float _progress;
    bool _move;

    public float Goto { get { return (_goto + 0.5f) * Screen.width; } set => _goto = (int)Mathf.Floor(value); }
    public float Lastpos { get { return (_lastpos + 0.5f) * Screen.width; } set => _lastpos = (int)Mathf.Floor(value); }

    [SerializeField] AnimationCurve _curve;



    private void Update()
    {
        if(_progress < 1 && _move)
        {
            _progress += Time.deltaTime;
            MoveUI();
        }
        else if(_move){
            _move = false;
            _lastpos = _goto;

        }
        
    }

    private void Awake()
    {
        _rect = GetComponent<RectTransform>();
    }
    public void Option()
    {
        Next(1);
    }
    public void Main()
    {
        Next(0);
    }
    public void Credit()
    {
        Next(-1);
    }
    private void Next(int next)
    {
        if(next != _goto)
        {
            _lastpos = _goto;
            _goto = next;
            Debug.Log("move");
            _move = true;
            _progress = 0;
        }
    }
    private void MoveUI()
    {
        _globalPanel.position = new Vector3(Mathf.Lerp(Lastpos, Goto, _curve.Evaluate(_progress)), _globalPanel.position.y, _globalPanel.position.z);
    }
}
