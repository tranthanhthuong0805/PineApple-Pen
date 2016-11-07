using UnityEngine;
using System.Collections;

public class ShopButton : MonoBehaviour {

    private bool playGame;
    private bool liveShop;

    // Update is called once per frame
    void Update()
    {
        ShopDestroy();

        if(liveShop)
        {
            liveShop = false;
            UnityEngine.SceneManagement.SceneManager.LoadScene("Shop");
//            Application.LoadLevel("Shop");
        }
    }

    public void PlayButton()
    {
        playGame = true;
    }

    public void LiveShopButton()
    {
        StartCoroutine(LoadShop(0.1f));
    }

    IEnumerator LoadShop(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        liveShop = true;
    }

    void ShopDestroy()
    {
        if (playGame)
        {
            Destroy(gameObject);
        }

    }
}
