using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    public GameObject player;
    public GameObject gameInfo; //通过游戏信息对象中的脚本中的一些方法改变总得分
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

    //当检测到碰撞时，删除发生碰撞的物体，并记入得分
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Key")
        {
            GameObject.Destroy(other.gameObject);
            //并非总分 其实是连击数 当接收到 判定线时连击数累加
            gameInfo.GetComponent<GameInformation>().accumulateScore();
            //Debug.Log("当前得分：" + score);
            source.PlayOneShot(soundEffect, 1F);
        }
        
    }

    //未使用
    void OnCollisionEnter(Collision other)
    {

        //Debug.Log("碰撞到物体的名字" + other.gameObject.name);

    }
}
