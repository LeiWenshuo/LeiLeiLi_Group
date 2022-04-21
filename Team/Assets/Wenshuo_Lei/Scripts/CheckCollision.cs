using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    public GameObject player;
    public GameObject gameInfo; //ͨ����Ϸ��Ϣ�����еĽű��е�һЩ�����ı��ܵ÷�
    public AudioClip soundEffect;
    public AudioSource source;

    private Transform m_transform;
    private Rigidbody m_rigidbody;

    //private int getScore;


    void Start()
    {
        m_transform = player.GetComponent<Transform>();
        m_rigidbody = player.GetComponent<Rigidbody>();
        source.GetComponent<AudioSource>();
        //getScore = 0;


    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            m_transform.Translate(Vector3.left * 17 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            m_transform.Translate(Vector3.right * 17 * Time.deltaTime);
        }
    }

    //����⵽��ײʱ��ɾ��������ײ�����壬������÷�
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Key")
        {
            GameObject.Destroy(other.gameObject);
            //�����ܷ� ��ʵ�������� �����յ� �ж���ʱ�������ۼ�
            gameInfo.GetComponent<GameInformation>().accumulateScore();
            //Debug.Log("��ǰ�÷֣�" + score);
            source.PlayOneShot(soundEffect, 1F);
        }
        
    }

    //δʹ��
    void OnCollisionEnter(Collision other)
    {

        //Debug.Log("��ײ�����������" + other.gameObject.name);

    }
}
