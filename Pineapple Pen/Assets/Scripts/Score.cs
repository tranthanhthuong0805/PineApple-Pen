using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public static int highScore;
    public static int score;
    Text text;

	// Use this for initialization
	void Awake () {
        Instance = this;
        score = 0;
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

    public void PlaySoundPpap()
    {
        GetComponent<AudioSource>().mute = false;
    }

    public void StopSoundPpap()
    {
        GetComponent<AudioSource>().mute = true;
    }

    public void MinVolumePpap()
    {
        GetComponent<AudioSource>().volume = 0;
    }

    public void MaxVolumePpap()
    {
        GetComponent<AudioSource>().volume = 1;
    }
	
	// Update is called once per frame
	void Update () {
        if(score != 0)
            text.text = score.ToString();
	}
}
