using UnityEngine;
using System.Collections;

public class BackShop : MonoBehaviour {

    private bool liveBack;

	public void BackButton () {
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
