using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound_BTN : MonoBehaviour
{
    public AudioClip mainSound;
    public AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EnterTheButton()
    {
        source.PlayOneShot(mainSound, 1F);
    }
}
