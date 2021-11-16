using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;

public class Google_Ads : MonoBehaviour
{
    InterstitialAd ad;
    public Text t;
    
    void Start()
    {
        MobileAds.Initialize(InitializationStatus => { });
    }
    
    void Request_Ad()
    {
        string Ad_ID = "ca-app-pub-5755293822993295/9618739726";
        
        if (ad != null)
            ad.Destroy();

        ad = new InterstitialAd(Ad_ID);
        ad.LoadAd(new AdRequest.Builder().Build());

    }

    public void Show_AD()
    {
        Request_Ad();

        if (ad.IsLoaded())
        {
            ad.Show();
            t.text = "Success";
        }
        else
        {
            Debug.Log("Error");
            t.text = "Fail";
        }
    }


}
