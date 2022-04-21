using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    //����һ��Transform���͵���CameraRotation��������ʵ�������ת
    public Transform CameraRotation;

    //��������˽�����͵���Mouse_X,Mouse_Y�ֱ���������������򻬶���ֵ
    private float Mouse_X;
    private float Mouse_Y;

    //���������
    public float MouseSensitivity;

    //����һ���������͵�������¼��X����ת�ĽǶ�
    public float xRotation;

    //����Updata����ÿһ֡����ִ�У����²��ܹ�����ǰһʱ�̵�ֵ 
    void Update()
    {
        Mouse_X = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        Mouse_Y = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

        xRotation = xRotation - Mouse_Y;
        //xRotationֵΪ��ʱ����Ļ���ƣ���xRotationֵΪ��ʱ����Ļ����

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        CameraRotation.Rotate(Vector3.up * Mouse_X);
        this.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
}
