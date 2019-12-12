using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderCharacterEffect : MonoBehaviour
{
    [SerializeField] Color color;
    List<Material> materials;
    // Start is called before the first frame update
    void Start()
    {
        materials = new List<Material>();
        RecursiveMaterial(this.gameObject);
        foreach(Material mat in materials)
        {
            mat.SetColor("_Color", color);
        }
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
        
    }
}
