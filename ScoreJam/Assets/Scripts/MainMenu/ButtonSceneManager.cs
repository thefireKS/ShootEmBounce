using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonSceneManager : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ShowAdv();

    
    public ParticleSystem particles;
    
    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }
    public void BackToMenu()
    {
        ShowAdv();
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }

    public void Continue()
    {
        Time.timeScale = 1f;
    }
}
