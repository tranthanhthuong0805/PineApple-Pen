﻿using UnityEngine;
using System.Collections;

public class NoAds : MonoBehaviour {

    private bool playGame;

	
	// Update is called once per frame
	void Update () {
        NoAdsDestroy();
	}

    public void PlayButton()
    {
        playGame = true;
    }

    void NoAdsDestroy()
    {
        if (playGame)
        {
            Destroy(gameObject);
        }

    }
}
