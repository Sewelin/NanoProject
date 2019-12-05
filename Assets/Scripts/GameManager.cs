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

    public Transform posSpawner1;
    public Transform posSpawner2;


    private float touchCooldown = 0.2f;
    private AbstractController touched;
    private bool touch = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckDir();
        if (touch && touchCooldown < 0)
        {
            Kill(touched);

            touch = false;
            touchCooldown = 0.2f;
            touched = null;
        }
        else if (touch) touchCooldown -= Time.deltaTime;
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

    public void Touch(GameObject character)
    {
        if(touch && touched.characterInfo.Character != character)
        {
            touch = false;
            touchCooldown = 0.2f;
            touched = null;

            Kill(controller1);
            Kill(controller2);
        }
        else
        {
            touch = true;
            touchCooldown = 0.2f;
            touched = (controller1.characterInfo.Character == character) ? controller1 : controller2;
        }
    }
    private void Kill(AbstractController character)
    {
        character.characterInfo.Character.AddComponent<Die>();
        Destroy(character.characterInfo.Saber.gameObject);
        character.New();
    }
}
