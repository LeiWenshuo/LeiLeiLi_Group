using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomKey_Lei : MonoBehaviour
{
    public GameObject key;
    private float t1, t2;
    private float x, z;

    //��ÿ��Ԥ�������ɵĿ�¡��ʩ�ӵ���
    public float pw_x;
    public float pw_y;
    public float pw_z=-1000.0f;

    void Start()
    {
        t1 = 0;
    }

    void FixedUpdate()
    {
        t2 = Time.fixedTime;
        if (t2 - t1 >= 1)
        {
            GameObject cloneKey;
            x = Random.Range(-9, 9);
            //z = Random.Range(-10, 10);

            cloneKey = (GameObject)Instantiate(key, new Vector3(x, 0.3f, -2.0f), Quaternion.identity);
            cloneKey.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 90));
            //cloneKey.GetComponent<Rigidbody>().AddForce(pw_x, pw_y, pw_z);

            //ʹ�õ�ÿ����¡���ĸ������������һ����z����ٶ�
            cloneKey.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -10);

            t1 = t2;
        }
    }


}
