using UnityEngine;
using System.Collections;

public class TapToShoot : MonoBehaviour {

    private bool playGame;

    // Update is called once per frame
    void Update()
    {
        TapToShootDestroy();
    }

    public void TapToShootButton()
    {
        playGame = true;
    }

    void TapToShootDestroy()
    {
        if (playGame)
        {
            Destroy(gameObject);
        }

    }
}
