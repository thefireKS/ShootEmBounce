using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonSceneManager : MonoBehaviour
{
    public ParticleSystem particles;
    
    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }

    public void Continue()
    {
        Time.timeScale = 1f;
    }
}
