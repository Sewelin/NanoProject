using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject character1Model; // TODO see in editor?
    public GameObject character2Model;
    public StateParameters verticalAttackParameters; // TODO see in editor?
    public StateParameters dashAttackParameters;
    public StateParameters backDashParameters;
    public StateParameters walkingParameters;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        if (Time.timeScale < 0.0001f)
        {
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0f;
        }
    }
}
