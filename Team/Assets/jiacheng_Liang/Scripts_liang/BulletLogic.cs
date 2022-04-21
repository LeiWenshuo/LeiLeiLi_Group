using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    [Tooltip("子弹飞行速度")]
    public float speed = 1;

    [Tooltip("子弹生命时长")]
    public float lifetime = 3;

    [Tooltip("爆炸的粒子特效的prefab")]
    public GameObject explosionEffect;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SelfDestroy", lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("* 子弹碰撞, other=" + other.name);

        if (!other.name.StartsWith("怪兽")) return;

        // 销毁子弹
        Destroy(this.gameObject);

        // 销毁对方节点
        Destroy(other.gameObject);

        // 创建一个粒子特效，表现爆炸效果
        GameObject effectNode = Instantiate(explosionEffect, null);
        effectNode.transform.position = this.transform.position;
        // 当粒子特效播放时，该节点会自毁
    }

    private void SelfDestroy()
    {
        Destroy(this.gameObject);
    }

}
