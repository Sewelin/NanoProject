using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    [SerializeField] RectTransform _globalPanel;
    UIPosition _uiPosition;

    [SerializeField] CanvasGroup main;
    [SerializeField] CanvasGroup start;
    [SerializeField] AnimationCurve curve;
    [SerializeField] float speed;

    bool _isMain = true;
    float progress = 1;

    public UIPosition UiPosition { get => _uiPosition; set => _uiPosition = value; }
    public RectTransform GlobalPanel { get => _globalPanel; set => _globalPanel = value; }

    private void Update()
    {
        if(_isMain && progress < 1)
        {
            progress += Time.deltaTime * speed;
            if (progress >= 1) progress = 1;
            main.alpha = curve.Evaluate(progress);
            start.alpha = 1 - main.alpha;
        }
        if (!_isMain && progress > 0)
        {
            progress -= Time.deltaTime * speed;
            if (progress <= 0) progress = 0;
            main.alpha = curve.Evaluate(progress);
            start.alpha = 1 - main.alpha;
        }
    }
    

    private void Awake()
    {
        _uiPosition = GetComponent<UIPosition>();
    }

    public void StartButton(bool isMain)
    {
        _isMain = isMain;
        main.interactable = _isMain;
        start.interactable = !_isMain;
    }
    public void OptionButton()
    {
        _uiPosition.Next(1);
    }
    public void MainButton()
    {
        _uiPosition.Next(0);
    }
    public void CreditButton()
    {
        _uiPosition.Next(-1);
    }
    public void ExitButton()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
    



}
