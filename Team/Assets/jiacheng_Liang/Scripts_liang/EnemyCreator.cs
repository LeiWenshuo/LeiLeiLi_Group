using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    [Tooltip("怪兽的 Prefab")]
    public GameObject enemyPrefab;

    [Tooltip("定时创建新的怪兽")]
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

        // 头转过来
        node.transform.localEulerAngles = new Vector3(0, 180, 0);

        // 添加一个随机的偏移量，避免被人堵住出生点
        float dx = Random.Range(-20, 20);
        node.transform.Translate(dx, 0, 0, Space.Self);

    }
}
