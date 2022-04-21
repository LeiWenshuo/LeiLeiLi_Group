using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    [Tooltip("前进速度")]
    public float zSpeed = 10;

    // 横移速度
    float xSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        // 每秒改变一次横移速度
        InvokeRepeating("SnakeMove", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        float dz = zSpeed * Time.deltaTime;
        float dx = xSpeed * Time.deltaTime;

        this.transform.Translate(dx, 0, dz, Space.Self);
    }

    // 蛇皮走位
    void SnakeMove()
    {
        // 4 种速度选项
        float[] options = { -10, -5, 5, 10 };

        int sel = Random.Range(0, options.Length);

        xSpeed = options[sel];
    }
}
