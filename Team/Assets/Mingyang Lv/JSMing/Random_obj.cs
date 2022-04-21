using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_obj : MonoBehaviour
{
    public GameObject obj;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 300; i++)

        {

            Instantiate(obj, new Vector3(Random.Range(5f, 530f), 1, Random.Range(3f, 200f)), Quaternion.identity);

        }
    }

    // Update is called once per frame
    
}
