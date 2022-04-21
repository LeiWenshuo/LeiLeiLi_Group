using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public AudioClip mainSound;
    public AudioSource source;
    //定义一个bool变量，判断游戏是否暂停
    private bool isPause;


    void Start()
    {
        //当游戏开始时先暂停
        Time.timeScale = 0;
        isPause = true;
        //
        source.GetComponent<AudioSource>();
        source.Pause();

    }

    void Update()
    {
        
    }

    public void GamePause()
    {
        Time.timeScale = 0;
        isPause = true;
        source.Pause();
    }

    public void GameContinue()
    {
        Time.timeScale = 1;
        isPause = false;
        source.PlayOneShot(mainSound, 1F);
    }

    public void SwitchPause_Continue()
    {
        if (isPause == true)
        {
            GameContinue();
        }
        else
        {
            GamePause();
        }
    }

    public void Load_Scene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
