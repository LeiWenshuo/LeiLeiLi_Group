using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    [Tooltip("子弹节点的预制体")]
    public GameObject bulletPrefab;

    [Tooltip("子弹节点的父节点")]
    public Transform bulletFolder;

    [Tooltip("子弹出生点")]
    public Transform firePoint;

    [Tooltip("开火间隔")]
    public float fireInterval = 0.1f;

    [Tooltip("平移速度")]
    public float moveSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", fireInterval, fireInterval);
    }

    // Update is called once per frame
    void Update()
    {
        float dx = 0;

        if (Input.GetKey(KeyCode.A))
        {
            dx = -moveSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            dx = moveSpeed;
        }
        this.transform.Translate(dx, 0, 0, Space.Self);
    }

    private void Fire()
    {
        // 实例化一个子弹节点
        GameObject node = Instantiate(bulletPrefab, bulletFolder);

        // 把子弹移动到出生点位置 
        node.transform.position = firePoint.position;
    }
    
}
