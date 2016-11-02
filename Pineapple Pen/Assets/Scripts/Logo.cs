using UnityEngine;
using System.Collections;

public class Logo : MonoBehaviour {

    private bool playGame;

    // Update is called once per frame
    void Update()
    {
        LogoDestroy();
    }

    public void LogoButton()
    {
        playGame = true;
    }

    void LogoDestroy()
    {
        if (playGame)
        {
            Destroy(gameObject);
        }

    }
}
