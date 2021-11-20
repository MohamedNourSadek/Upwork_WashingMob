using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;

public class Ads_Manager : MonoBehaviour
{
    DatabaseReference reference;

    public bool state = false;

    [SerializeField] Google_Ads google;
    [SerializeField] Ad_Invoke unity;


    private void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        FirebaseDatabase.DefaultInstance.GetReference("state").ValueChanged += State_Update;
        FirebaseDatabase.DefaultInstance.GetReference("Unity_UnitID").ValueChanged += UnityID_Update;
        FirebaseDatabase.DefaultInstance.GetReference("Google_UnitID").ValueChanged += GoogleID_Update;
    }

    public void State_Update(object sender, ValueChangedEventArgs args)
    {
        state =  (bool)(args.Snapshot.Value);
        Debug.Log(state);
    }

    public void UnityID_Update(object sender, ValueChangedEventArgs args)
    {
        unity._androidAdUnitId = (string)(args.Snapshot.Value);
        Debug.Log(unity._androidAdUnitId);
    }

    public void GoogleID_Update(object sender, ValueChangedEventArgs args)
    {
        google.Ad_ID = (string)(args.Snapshot.Value);
        Debug.Log(google.Ad_ID);
    }


    public void ShowAd()
    {
        if (state)
            google.Show_AD();
        else
            unity.ShowAd();
    }
}
