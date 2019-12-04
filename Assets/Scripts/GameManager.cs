using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject character1Model; // TODO see in editor?
    public GameObject character2Model;
    public StateParameters verticalAttackParameters; // TODO see in editor?
    public StateParameters dashAttackParameters;
    public StateParameters backDashParameters;
    public float walkingSpeed;
    public AbstractController controller1;
    public AbstractController controller2;
    public bool controller1Assigned;
    public bool controller2Assigned;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckDir();
    }

    public void Pause()
    {// TODO check and ...
        if (Time.timeScale < 0.0001f)
        {
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0f;
        }
    }
    
    

    public void CheckDir()
    {
        if (!controller1Assigned || !controller2Assigned) return;
        if (!controller1.characterInfo.characterAssigned || !controller2.characterInfo.characterAssigned) return;

        controller1.dir = (int) Mathf.Sign(controller2.characterInfo.Character.transform.position.x -
                                           controller1.characterInfo.Character.transform.position.x);
        controller2.dir = -controller1.dir;
        
        var v = controller1.characterInfo.Character.transform.localScale;
        v.x = controller1.dir;
        controller1.characterInfo.Character.transform.localScale = v;
        
        v = controller2.characterInfo.Character.transform.localScale;
        v.x = controller2.dir;
        controller2.characterInfo.Character.transform.localScale = v;
    }
}
