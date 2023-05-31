using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score;
    private TextMeshProUGUI scoreCounterText;
    void Start()
    {
        score = 0;
        scoreCounterText = GetComponent<TextMeshProUGUI>();
        scoreCounterText.text = score.ToString();
                
    }

    public void Scored ()
    {
        score++;
        scoreCounterText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
