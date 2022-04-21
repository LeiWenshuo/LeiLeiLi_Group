using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollisionLink : MonoBehaviour
{
    //通过游戏信息对象中的脚本中的一些方法改变总得分(与玩家控制与检查碰撞1脚本方法类似)
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
        //Debug.Log("碰撞到判定线" + other.gameObject.name);
        if (other.gameObject.tag == "Key")
        {
            GameObject.Destroy(other.gameObject);
            //并非总分 其实是连击数 当碰到判定线时连击数归零
            gameInfo.GetComponent<GameInformation>().setScore(0);

            switchMaterial.GetComponent<ChangeMaterial>().SwitchMaterial();
        }
    }
}
