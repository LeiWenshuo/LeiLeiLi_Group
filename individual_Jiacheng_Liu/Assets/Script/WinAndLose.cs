﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinAndLose : MonoBehaviour
{



    public Button GameAgainButton;
    public Button GameQuitButton;

    // Use this for initialization
    void Start()
    {
        GameAgainButton.onClick.AddListener(GameAgainButtonClickListener);         
        GameQuitButton.onClick.AddListener(GameQuitButtonClickListener);             
    }


    void GameAgainButtonClickListener()
    {
        SceneManager.LoadScene(2);
    }

    void GameQuitButtonClickListener()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
      Application.Quit();
#endif
    }


}
