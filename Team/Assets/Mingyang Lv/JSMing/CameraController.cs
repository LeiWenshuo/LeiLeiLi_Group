using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    //创建一个Transform类型的量CameraRotation用来保存实现相机旋转
    public Transform CameraRotation;

    //定义两个私有类型的量Mouse_X,Mouse_Y分别接收鼠标向各个方向滑动的值
    private float Mouse_X;
    private float Mouse_Y;

    //鼠标灵敏度
    public float MouseSensitivity;

    //定义一个浮点类型的量，记录绕X轴旋转的角度
    public float xRotation;

    //放在Updata里面每一帧都会执行，导致不能够保存前一时刻的值 
    void Update()
    {
        Mouse_X = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        Mouse_Y = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

        xRotation = xRotation - Mouse_Y;
        //xRotation值为正时，屏幕下移，当xRotation值为负时，屏幕上移

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        CameraRotation.Rotate(Vector3.up * Mouse_X);
        this.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
}
