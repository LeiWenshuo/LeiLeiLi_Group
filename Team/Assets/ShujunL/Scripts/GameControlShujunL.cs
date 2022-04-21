using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControlShujunL : MonoBehaviour
{

    public Button GameOver_Button;
    public Button GameStart_Button;
    public Button GameAgain_Button;

    public GameObject Player;
    public GameObject PlayGame;
    public GameObject GameStart;

    public GameObject HelpPanle;
    public Button OpenHelpBtn;
    public Button CloseHelpBtn;
    public Button menuHelpBtn;


    // Use this for initialization
    void Start()
    {
        GameOver_Button.onClick.AddListener(GameOver_Buttonlistener);
        GameStart_Button.onClick.AddListener(GameStart_Buttonlistener);
        GameAgain_Button.onClick.AddListener(GameAgain_ButtonLis);

        OpenHelpBtn.onClick.AddListener(OpenHelpBtnLis);
        CloseHelpBtn.onClick.AddListener(CloseHelpBtnLis);

        menuHelpBtn.onClick.AddListener(menuHelpBtnLis);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GameOver_Buttonlistener()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
      Application.Quit();
#endif
    }

    void GameStart_Buttonlistener()
    {
        Player.SetActive(true);
        PlayGame.SetActive(true);
        GameStart.SetActive(false);
    }

    void GameAgain_ButtonLis()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OpenHelpBtnLis()
    {
        HelpPanle.SetActive(true);
    }

    public void CloseHelpBtnLis()
    {
        HelpPanle.SetActive(false);
    }

    public void menuHelpBtnLis()
    {
        SceneManager.LoadScene(0);
    }


}
