using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Sound : MonoBehaviour {

    public Sprite sound1;
    public Sprite sound2;
    public Sprite sound3;
    private int temp;

    private AudioSource audio;
    public AudioClip ppap, trigger, gameOver, click, intro, coinsSplash5;

    private bool onePpap;       //Tránh lặp audio

    public static Sound Instance { get; private set; }

    //Âm thanh va chạm với swag
    public void SoundCoinsSplash5()
    {
        audio.PlayOneShot(coinsSplash5);
    }

    //Âm thanh click button
    public void SoundClick()
    {
        audio.PlayOneShot(click);
    }

    //Âm thanh va chạm
    public void SoundTrigger()
    {
        audio.PlayOneShot(trigger);
    }

    //Âm thanh gameover
    public void SoundGameOver()
    {
        audio.PlayOneShot(gameOver);
    }

    public void SoundStop()
    {
        audio.Stop();
    }

    //Đổi sprite
    public void SoundButton()
    {
        temp++;
        if (temp == 4)
            temp = 1;
        PlayerPrefs.SetInt("Sound", temp);
        SoundClick();
    }

	// Use this for initialization
	void Awake () {
        Instance = this;
        audio = GetComponent<AudioSource>();
	}

    void Start()
    {
        temp = PlayerPrefs.GetInt("Sound");
        if(temp != 3)
        {
            audio.PlayOneShot(intro);
        }
    }
	
	// Update is called once per frame
	void Update () {
        GameObject[] emotions = GameObject.FindGameObjectsWithTag("Emotion");
        if (temp == 1)
        {
            this.transform.GetComponent<Image>().sprite = sound1;
            if (emotions.Length != 0)
            {
                for (int i = 0; i < emotions.Length; i++)
                {
                    emotions[i].GetComponent<AudioSource>().volume = 1;
                }
            }
            audio.volume = 1;
            Score.Instance.MaxVolumePpap();
        }
        else if (temp == 2)
        {

            this.transform.GetComponent<Image>().sprite = sound2;
            if (emotions.Length != 0)
            {
                for (int i = 0; i < emotions.Length; i++)
                {
                    emotions[i].GetComponent<AudioSource>().volume = 0;
                }
            }
        }
        else if (temp == 3)
        {
            this.transform.GetComponent<Image>().sprite = sound3;
            if (emotions.Length != 0)
            {
                for (int i = 0; i < emotions.Length; i++)
                {
                    emotions[i].GetComponent<AudioSource>().volume = 0;
                }
            }
            audio.volume = 0;
            Score.Instance.MinVolumePpap();
        }
	}
}
