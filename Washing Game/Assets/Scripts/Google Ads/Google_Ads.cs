using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class Google_Ads : MonoBehaviour
{
    InterstitialAd ad;

    void Start()
    {
        MobileAds.Initialize(InitializationStatus => { });
    }

    void Request_Ad()
    {
        string Ad_ID = "ca-app-pub-5755293822993295~5777188320";
        
        if (ad != null)
            ad.Destroy();

        ad = new InterstitialAd(Ad_ID);
        ad.LoadAd(new AdRequest.Builder().Build());

    }

    public void Show_AD()
    {
        Request_Ad();

        if (ad.IsLoaded())
            ad.Show();
        else
            Debug.Log("Error");
    }


}