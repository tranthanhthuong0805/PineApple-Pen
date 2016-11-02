using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public static int highScore;
    public static int score;
    public static int coin;
    Text text;

	// Use this for initialization
	void Awake () {
        Instance = this;
        score = 0;
        coin = 0;
        highScore = PlayerPrefs.GetInt("highScore");
        text = GetComponent<Text>();
	}

    public static Score Instance { get; private set; }

    public void SetScore(int value)
    {
        score += value;
    }

    public void SaveHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highScore", highScore);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if(score != 0)
            text.text = score.ToString();
	}
}
