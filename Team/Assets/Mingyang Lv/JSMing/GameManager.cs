using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


[AddComponentMenu("Game/GameManager")]
public class GameManager : MonoBehaviour
{

    public static GameManager Instance = null;

    public int m_score = 0;

    public Text txt_score;

    public Button Button_Shezhi;
    public GameObject StopPanel;  

    public Button GameAgainPlayButton; 
    public Button GameRePlayButton;   
    public Button GameQuitButton;     


    // Use this for initialization
    void Start()
    {
        Instance = this;

        GameAgainPlayButton.onClick.AddListener(GameAgainPlayButtonListener);   
        GameRePlayButton.onClick.AddListener(GameRePlayButtonClickListener);   
        GameQuitButton.onClick.AddListener(GameQuitButtonClickListener);        

        Button_Shezhi.onClick.AddListener(StopButtonClickListener);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            StopButtonClickListener();
        }

 
    }


    public void SetScore(int score)
    {
        m_score += score;

       txt_score.text = m_score.ToString();

        if (m_score >= 3)
        {
            //  Time.timeScale = 0;
           // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }

    void StopButtonClickListener()
    {
        StopPanel.SetActive(true);
        Time.timeScale = 0;
    }

    void GameAgainPlayButtonListener()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    void GameRePlayButtonClickListener()
    {
        StopPanel.SetActive(false);

        Time.timeScale = 1;
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