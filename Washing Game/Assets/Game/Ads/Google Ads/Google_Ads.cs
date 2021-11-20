using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;

public class Google_Ads : MonoBehaviour
{
    [SerializeField] public string Ad_ID;

    InterstitialAd ad;
    public Text t;
    
    void Start()
    {
        MobileAds.Initialize(InitializationStatus => { });
        t.text += MobileAds.Instance + "\n";
    }
    
    void Request_Ad()
    {
        
        if (ad != null)
            ad.Destroy();


        ad = new InterstitialAd(Ad_ID);
        ad.LoadAd(new AdRequest.Builder().Build());

        t.text += ad.IsLoaded() + "\n";
    }

    public void Show_AD()
    {
        Request_Ad();


        if (ad.IsLoaded())
        {
            ad.Show();
            t.text += "Success  \n";
        }
        else
        {
            Debug.Log("Error");
            t.text = "Fail + \n";
        } 
    }


}
