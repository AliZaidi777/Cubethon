using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    public Text HighScoreText;
    int Score;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetInt("HighScore", 0);
        HighScoreText.text = PlayerPrefs.GetInt("HScore").ToString();

    }

    // Update is called once per frame
    void Update()
    {
        Score = (int)player.position.z;
        scoreText.text = Score.ToString();
        if (PlayerPrefs.GetInt("HighScore") < Score)
        {
            PlayerPrefs.SetInt("HighScore", Score);
            
            PlayerPrefs.SetInt("HScore", PlayerPrefs.GetInt("HighScore"));
            HighScoreText.text = PlayerPrefs.GetInt("HScore").ToString();
        }

    }
}
