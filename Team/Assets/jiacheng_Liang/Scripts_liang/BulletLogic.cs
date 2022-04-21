using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    [Tooltip("�ӵ������ٶ�")]
    public float speed = 1;

    [Tooltip("�ӵ�����ʱ��")]
    public float lifetime = 3;

    [Tooltip("��ը��������Ч��prefab")]
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
        Debug.Log("* �ӵ���ײ, other=" + other.name);

        if (!other.name.StartsWith("����")) return;

        // �����ӵ�
        Destroy(this.gameObject);

        // ���ٶԷ��ڵ�
        Destroy(other.gameObject);

        // ����һ��������Ч�����ֱ�ըЧ��
        GameObject effectNode = Instantiate(explosionEffect, null);
        effectNode.transform.position = this.transform.position;
        // ��������Ч����ʱ���ýڵ���Ի�
    }

    private void SelfDestroy()
    {
        Destroy(this.gameObject);
    }

}
