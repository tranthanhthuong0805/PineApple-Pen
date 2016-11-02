﻿using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class ShowAds : MonoBehaviour {

#if !UNITY_ADS // If the Ads service is not enabled...
    public string gameId = "1183143"; // Set this value from the inspector.
    public bool enableTestMode = true;
#endif

    IEnumerator Start()
    {
#if !UNITY_ADS // If the Ads service is not enabled...
        if (Advertisement.isSupported)
        { // If runtime platform is supported...
            Advertisement.Initialize(gameId, enableTestMode); // ...initialize.
        }
#endif

        // Wait until Unity Ads is initialized,
        //  and the default ad placement is ready.
        while (!Advertisement.isInitialized || !Advertisement.IsReady())
        {
            yield return new WaitForSeconds(0.5f);
        }

        // Show the default ad placement.
        //Advertisement.Show();
    }

    public void ShowAd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
    }
}
