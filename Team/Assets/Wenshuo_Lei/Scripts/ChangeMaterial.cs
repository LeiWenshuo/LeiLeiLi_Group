using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public GameObject link;
    public Material unchangedMaterial;
    public Material changedMaterial;
    private bool isChangedMaterial;

    // Start is called before the first frame update
    void Start()
    {
        isChangedMaterial = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SwitchMaterial()
    {
        if (isChangedMaterial == false)
        {
            link.GetComponent<MeshRenderer>().materials[0].CopyPropertiesFromMaterial(changedMaterial);
            isChangedMaterial = true;
        }
        else
        {
            link.GetComponent<MeshRenderer>().materials[0].CopyPropertiesFromMaterial(unchangedMaterial);
            isChangedMaterial = false;
        }
    }
}
