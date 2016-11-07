using UnityEngine;
using System.Collections;

public class BackShop : MonoBehaviour {

    private bool liveBack;
    private AudioSource audio;
    public AudioClip click;

    void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    public void SoundClick()
    {
        audio.PlayOneShot(click);
    }

	public void BackButton () {
        StartCoroutine(LoadGamePlay(0.01f));
	}

    IEnumerator LoadGamePlay(float seconds)
    {
        SoundClick();
        yield return new WaitForSeconds(seconds);
        liveBack = true;
    }
	
	// Update is called once per frame
	void Update () {
	    if(liveBack)
        {
            liveBack = false;
            
            UnityEngine.SceneManagement.SceneManager.LoadScene("GamePlay");
            //Application.LoadLevel("GamePlay");
        }
	}
}
