using UnityEngine;

[System.Serializable]
public struct StateParameters
{
    public Vector3 timeSteps;
    public AnimationCurve curve;
    public float speed;
    
    public float Duration => timeSteps.x + timeSteps.y + timeSteps.z;
}