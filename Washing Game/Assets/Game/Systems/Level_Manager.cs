using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Manager : MonoBehaviour
{
    [SerializeField] int currentLevel = 0;
    [SerializeField] List<Level_data> Levels;
    [SerializeField] Transform ParentLevelObject;
    [SerializeField] Ads_Manager ad;


    GameObject currentobject;
    string save_var = "level";

    void Awake()
    {
        Load_level();
    }

    void Load_level()
    {
        currentLevel = PlayerPrefs.GetInt(save_var);

        if (currentobject)
            Destroy(currentobject.gameObject);

        currentobject = Instantiate(Levels[currentLevel].LevelObject, ParentLevelObject);
    }

    public void Next_level()
    {
        if(currentLevel < Levels.Count - 1)
        {
            currentLevel++;
            PlayerPrefs.SetInt(save_var, currentLevel);

            Load_level();
            ad.ShowAd();
        }
        else
        {
            //loading End game screen
            SceneManager.LoadScene(2);
        }
    }
}


[System.Serializable] 
public class Level_data
{
    [SerializeField] public GameObject LevelObject;
}
