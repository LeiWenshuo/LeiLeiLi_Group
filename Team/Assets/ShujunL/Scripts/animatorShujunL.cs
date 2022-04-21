using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatorShujunL : MonoBehaviour
{

    private Animation _animation; 
    private CharacterController controller;


    // Start is called before the first frame update
    void Start()
    {
        _animation = this.GetComponent<Animation>();
        controller = GetComponent<CharacterController>();

        _animation["SC_D_Idle"].speed = 2;
        _animation["SC_D_Run"].speed = 2;
    }


    // Update is called once per frame
    void Update()
    {
     
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKeyUp(KeyCode.Space))
        {
            _animation.Play("SC_D_Run");    
        }
        else
        {
            if (controller.isGrounded)
            {
                {
                    _animation.Play("SC_D_Idle");
                }
            }
        }    
    }
}
