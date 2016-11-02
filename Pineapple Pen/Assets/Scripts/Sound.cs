using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Sound : MonoBehaviour {

    public Sprite sound1;
    public Sprite sound2;
    public Sprite sound3;
    private int temp = 1;

    private AudioSource audio;
    public AudioClip ppap, trigger, gameOver;
    public AudioClip Trigger
    {
        get { return trigger; }
        set { trigger = value; }
    }
    public AudioClip GameOver
    {
        get { return gameOver; }
        set { gameOver = value; }
    }

    private bool onePpap;       //Tránh lặp audio

    //Đổi sprite
    public void SoundButton()
    {
        if (temp == 3)
            temp = 1;
        else
            temp++;
    }

	// Use this for initialization
	void Awake () {
        audio = GetComponent<AudioSource>();
        audio.clip = ppap;
	}
	
	// Update is called once per frame
	void Update () {
        if (temp == 1)
        {
            this.transform.GetComponent<Image>().sprite = sound1;
        }
        else if (temp == 2)
            this.transform.GetComponent<Image>().sprite = sound2;
        else if (temp == 3)
            this.transform.GetComponent<Image>().sprite = sound3;

        if (Score.score > 0)
        {
            GameObject pen = GameObject.FindGameObjectWithTag("Pen");

            if (onePpap == false && !audio.isPlaying)
                audio.PlayOneShot(ppap);
            if (onePpap == false && audio.isPlaying)
                onePpap = true;
            if (pen == null)
                audio.Stop();

        }
	}
}
