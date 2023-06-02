using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score;
    private TextMeshProUGUI scoreCounterText;
    int highScore;

    public TextMeshProUGUI panelScore;
    public TextMeshProUGUI panelHighScore;
    public GameObject New;
    void Start()
    {
        score = 0;
        scoreCounterText = GetComponent<TextMeshProUGUI>();
        scoreCounterText.text = score.ToString();
        panelScore.text = highScore.ToString();
        highScore = PlayerPrefs.GetInt("highscore");
        panelHighScore.text = highScore.ToString();
                
    }

    public void Scored ()
    {
        score++;
        scoreCounterText.text = score.ToString();
        panelScore.text = score.ToString() ;
        if ( highScore < score)
        {
            highScore = score;
            panelHighScore.text = highScore.ToString();
            PlayerPrefs.SetInt("highscore", highScore);
            New.SetActive(true);
        }
    }

    public int GetScore()
    {
        return score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
