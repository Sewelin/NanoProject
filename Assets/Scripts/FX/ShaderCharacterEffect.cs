using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderCharacterEffect : MonoBehaviour
{
    [SerializeField] public Color color;
    List<Material> materials;
    float timerConsum = 1;
    float SPEED = 0.05f;
    bool beginConsum;
    public ParticleSystem particle;

    GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        materials = new List<Material>();
        RecursiveMaterial(this.gameObject);
        foreach(Material mat in materials)
        {
            mat.SetColor("_Color", color);
        }

        _gameManager = FindObjectOfType<GameManager>();
    }
    void RecursiveMaterial(GameObject go)
    {
        if(go.TryGetComponent<Renderer>(out _))
            materials.Add(go.GetComponent<Renderer>().material);
        for(int i = 0; i< go.transform.childCount; ++i)
        {
            RecursiveMaterial(go.transform.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(beginConsum && timerConsum > 0) { 
            timerConsum -= Time.deltaTime * SPEED;

            foreach (Material mat in materials)
            {

                mat.SetFloat("_Progress", 1-timerConsum);
                if(timerConsum < 0.5f)
                {
                    particle.Stop();
                }
            }
            if (timerConsum < 0) Destroy(gameObject);

        }
       
    }
    public void BeginConsum()
    {
        beginConsum = true;
        AkSoundEngine.PostEvent("SFX_ConsumeCorps", _gameManager.soundManager);
    }
}
