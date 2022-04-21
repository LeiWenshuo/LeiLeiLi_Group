using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public AudioClip mainSound;
    public AudioSource source;
    //����һ��bool�������ж���Ϸ�Ƿ���ͣ
    private bool isPause;


    void Start()
    {
        //����Ϸ��ʼʱ����ͣ
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
