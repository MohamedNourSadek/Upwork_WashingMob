using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level_Manager : MonoBehaviour
{
    [SerializeField] int currentLevel = 0;
    [SerializeField] List<Level_data> Levels;
    [SerializeField] Transform ParentLevelObject;
    [SerializeField] Slider Score;
    [SerializeField] Ads_Manager ad;
    [SerializeField] AudioClip level_complete;
    [SerializeField] Text level;
    [SerializeField] Image Level_transition;
    [SerializeField] Player_Controller player;

    GameObject currentobject;
    string save_var = "level";

    void Awake()
    {
        Load_level();
    }

    public void Load_level()
    {
        Level_transition.gameObject.SetActive(false);
        player.playing = true;

        currentLevel = PlayerPrefs.GetInt(save_var);
        level.text = "Level " + (currentLevel + 1).ToString();

        if (currentobject)
            Destroy(currentobject.gameObject);

        currentobject = Instantiate(Levels[currentLevel].LevelObject, ParentLevelObject);
        Score.maxValue = Levels[currentLevel].MaxScore;

        var Dirt = currentobject.GetComponentsInChildren<Dirt_Object>();
        foreach (Dirt_Object d in Dirt)
            d.man = this;
    }

    public void Add_Score(float addedScore)
    {
        Score.value += addedScore;

        if (Score.value == Score.maxValue)
            Next_level();
    }

    IEnumerator ShowAd_Delayed()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        ad.ShowAd();
    }

    public void Next_level()
    {
        player.playing = false;

        if (currentLevel < Levels.Count - 1)
        {
            currentLevel++;
            PlayerPrefs.SetInt(save_var, currentLevel);
            Score.value = 0;
            AudioSource.PlayClipAtPoint(level_complete, Camera.main.transform.position);

            Level_transition.gameObject.SetActive(true);
            StartCoroutine(ShowAd_Delayed());
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
    [SerializeField] public float MaxScore;
}

