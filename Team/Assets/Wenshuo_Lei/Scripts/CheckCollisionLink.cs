using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollisionLink : MonoBehaviour
{
    //ͨ����Ϸ��Ϣ�����еĽű��е�һЩ�����ı��ܵ÷�(����ҿ���������ײ1�ű���������)
    public GameObject gameInfo;
    public GameObject switchMaterial;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log("��ײ���ж���" + other.gameObject.name);
        if (other.gameObject.tag == "Key")
        {
            GameObject.Destroy(other.gameObject);
            //�����ܷ� ��ʵ�������� �������ж���ʱ����������
            gameInfo.GetComponent<GameInformation>().setScore(0);

            switchMaterial.GetComponent<ChangeMaterial>().SwitchMaterial();
        }
    }
}
