using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {

    private bool liveRestart;

    public void RestartButton()
    {
        StartCoroutine(LoadGamePlay(0.1f));
    }

    IEnumerator LoadGamePlay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        liveRestart = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (liveRestart)
        {
            liveRestart = false;

            UnityEngine.SceneManagement.SceneManager.LoadScene("GamePlay");
            //Application.LoadLevel("GamePlay");
        }
    }

}
