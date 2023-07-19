using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitializer : MonoBehaviour
{
    public string gameId = "your_game_id";
    public bool testMode = false;

    // Start is called before the first frame update
    void Start()
    {
        InitializeAds();
    }

    private void InitializeAds()
    {
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize(gameId, testMode);
        }
        else
        {
            Debug.Log("Unity Ads is not supported on this platform");
        }
    }
}