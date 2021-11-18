using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End_Game_Buttons : MonoBehaviour
{
    public void Restart_Game()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }

    public void Exit_Game()
    {
        Application.Quit();
    }
}
