using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> menus;
    
    [SerializeField] private GameObject fading;
    private Animator _fadeAnimator;

    private PlayerData _playerData;

    private void Start()
    {
        _fadeAnimator = fading.GetComponent<Animator>();

        _playerData = FindObjectOfType<PlayerData>();
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private string _currentMenu;

    public void SetActiveMenu(string menuName)
    {
        _currentMenu = menuName;
        foreach (var menu in menus)
        {
            if (menu.name == _currentMenu)
            {
                menu.SetActive(true);
            }
            else
            {
                menu.SetActive(false);
            }
        }
        Fade();
    }

    private void Fade()
    {
        _fadeAnimator.Play("LoadAnim");
    }

    public void LoadScene()
    {
        var sceneName = _playerData.chosenArena;
        SceneManager.LoadScene(sceneName);
    }
}
