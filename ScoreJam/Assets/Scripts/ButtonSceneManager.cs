using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonSceneManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Continue()
    {
        Time.timeScale = 1f;
    }
}
