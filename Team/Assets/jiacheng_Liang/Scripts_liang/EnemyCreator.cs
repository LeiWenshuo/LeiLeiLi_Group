using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    [Tooltip("���޵� Prefab")]
    public GameObject enemyPrefab;

    [Tooltip("��ʱ�����µĹ���")]
    public float interval = 1;

    // Start is called before the first frame update
    void Start()
    {
        // CreateEnemy();
        InvokeRepeating("CreateEnemy", 0.1f, interval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateEnemy()
    {
        GameObject node = Instantiate(enemyPrefab, this.transform);
        node.transform.position = this.transform.position;

        // ͷת����
        node.transform.localEulerAngles = new Vector3(0, 180, 0);

        // ���һ�������ƫ���������ⱻ�˶�ס������
        float dx = Random.Range(-20, 20);
        node.transform.Translate(dx, 0, 0, Space.Self);

    }
}
