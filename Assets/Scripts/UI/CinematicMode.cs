using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicMode : MonoBehaviour
{
    public bool active = false;
    Vector2 origin;
    float _progress = 0;
    [SerializeField] float speed;
    [SerializeField] RectTransform top;
    [SerializeField] RectTransform bottom;
    [SerializeField] AnimationCurve curve;


    // Start is called before the first frame update
    void Start()
    {
        top.sizeDelta = new Vector2(0, (Screen.height - (Screen.width * 9 / 21)) / 2);
        bottom.sizeDelta = top.sizeDelta;

        top.transform.position = new Vector2(top.transform.position.x, top.transform.position.y + top.sizeDelta.y);
        bottom.transform.position = new Vector2(bottom.transform.position.x, bottom.transform.position.y - bottom.sizeDelta.y);
        origin = new Vector2(top.transform.position.y, bottom.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (active && _progress < 1)
        {
            _progress += Time.deltaTime * speed;
            if (_progress > 1) _progress = 1;
            top.transform.position = new Vector2(top.transform.position.x, origin.x - top.sizeDelta.y * curve.Evaluate(_progress));
            bottom.transform.position = new Vector2(bottom.transform.position.x, origin.y + bottom.sizeDelta.y * curve.Evaluate(_progress));
        }
        else if(!active && _progress > 0)
        {
            _progress -= Time.deltaTime * speed;
            if (_progress < 0) _progress = 0;
            top.transform.position = new Vector2(top.transform.position.x, origin.x - top.sizeDelta.y * curve.Evaluate(_progress));
            bottom.transform.position = new Vector2(bottom.transform.position.x, origin.y + bottom.sizeDelta.y * curve.Evaluate(_progress));
        }
    }
}
