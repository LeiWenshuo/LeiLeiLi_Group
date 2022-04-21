using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public AudioClip mainSound;
    public AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source.Play();
    }

   
}
