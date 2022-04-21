using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * This class class set the mouse actions.
 * @Lileilei
 */
public class CameraTurn_Lileilei : MonoBehaviour
{
    // horizital sensitivity
    public float sensitivityHor = 3f;
    // Horizental sensitity
    public float sensitivityVer = 3f;
    // up view 
    public float upVer = -40;
    // down view
    public float downVer = 45;
    // vertical rover angle
    private float rotVer;

    // Direction of rotation  
    // x represents rotation about the X-axis  
    // y stands for rotation about the Y-axis, i.e. left and back Angle  


    // Start is called before the first frame update
    void Start()
    {
        //initialize the speed
        rotVer = transform.eulerAngles.x;
    }

    // Update is called once per frame
    void Update()
    {
        // get mouse vertical movement
        float mouseVer = Input.GetAxis("Mouse Y");
        // get mouse horiizental movement
        float mouseHor = Input.GetAxis("Mouse X");
        // mouse moving is negative collerated with player's view. So there is a -.
        rotVer -= mouseVer * sensitivityVer;
        // limit rober angle
        rotVer = Mathf.Clamp(rotVer, upVer, downVer);
        // horizental movement
        float rotHor = transform.localEulerAngles.y + mouseHor * sensitivityHor;
        // set local angle
        transform.localEulerAngles = new Vector3(rotVer, rotHor, 0);
    }
}