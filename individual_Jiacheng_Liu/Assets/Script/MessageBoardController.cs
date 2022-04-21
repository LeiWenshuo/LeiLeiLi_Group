using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MessageBoardController : MonoBehaviour
{

    public Player m_player; 

    public Text Text_num_01;
    public Text Text_num_02;
    public Text Text_num_03;
    public Text Text_num_04;
    public Text Text_num_05;

    public int num_01 = 0;
    public int num_02 = 0;
    public int num_03 = 0;
    public int num_04 = 0;
    public int num_05 = 0;

    // Start is called before the first frame update
    void Start()
    {
        Text_num_01.text = num_01.ToString();
        Text_num_02.text = num_02.ToString();
        Text_num_03.text = num_03.ToString();
        Text_num_04.text = num_04.ToString();
        Text_num_05.text = num_05.ToString();
    }

    // Update is called once per frame
    void Update()
    {
 
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            if (num_01 > 0 && m_player.life != 100)
            {
                num_01--;
                Text_num_01.text = num_01.ToString();

                m_player.AddHp();
            }    
        }

        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            if (num_02 > 0 && m_player.SP_life != 100)
            {
                num_02--;
                Text_num_02.text = num_02.ToString();

                m_player.AddSp();
            }
        }
    }

    public void Add_01()
    {
        num_01++;
        Text_num_01.text = num_01.ToString();
    }

    public void Add_02()
    {
        num_02++;
        Text_num_02.text = num_02.ToString();
    }

    public void Add_03()
    {
        num_03++;
        Text_num_03.text = num_03.ToString();
    }

    public void Add_04()
    {
        num_04++;
        Text_num_04.text = num_04.ToString();
    }

    public void Add_05()
    {
        num_05++;
        Text_num_05.text = num_05.ToString();

        if (num_05 == 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }

}
