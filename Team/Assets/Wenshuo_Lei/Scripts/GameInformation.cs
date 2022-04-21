using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInformation : MonoBehaviour
{
    public int score,totalScore;
    public Text scoreText;
    public GameObject gameController;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        totalScore = 5;
        scoreText = GameObject.FindWithTag("ComboText").GetComponent<Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        scoreText.text = "Combo：" + score.ToString();
        //如果得分达到目标分数则加载胜利界面
        if (score >= totalScore)
        {
            gameController.GetComponent<GameControl>().Load_Scene("WinnerScene_Lei");
        }
    }
    
    public void setScore(int score)
    {
        this.score = score;
    }

    public void accumulateScore()
    {
        score++;
    }

    public void printScore()
    {
        
        //Debug.Log("当前得分：" + this.score);
    }


}
