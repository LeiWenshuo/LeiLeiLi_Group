using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * This is the menu playsound class.
 */
public class Sound_paly : MonoBehaviour
{

    public AudioClip mainSound;
    public AudioSource source;
    public AudioSource backgroundMusic;
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
