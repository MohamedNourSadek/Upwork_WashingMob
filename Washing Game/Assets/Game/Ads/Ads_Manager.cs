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
        FirebaseDatabase.DefaultInstance.GetReference("state").ValueChanged += HandleUpdate;
    }

    public void HandleUpdate(object sender, ValueChangedEventArgs args)
    {
        state =  (bool)(args.Snapshot.Value);
        Debug.Log(state);
    }

    public void ShowAd()
    {
        if (state)
            google.Show_AD();
        else
            unity.ShowAd();

        Debug.Log(reference.GetValueAsync());
    }
}
