using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct StateInfo
{
    public float time;
    public AnimationCurve moveCurve;
    public float speed;
    public float cooldown;
}
