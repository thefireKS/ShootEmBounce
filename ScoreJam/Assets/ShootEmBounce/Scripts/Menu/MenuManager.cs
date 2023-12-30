using System;
using System.Collections.Generic;
using ShootEmBounce.Scripts.Player;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> menus;

    private Data _data;

    public static event Action MenuChanged;

    private void Start()
    {

        //_data = FindObjectOfType<Data>();
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private string _currentMenu;

    public void SetActiveMenu(string menuName)
    {
        _currentMenu = menuName;
        foreach (var menu in menus)
        {
            menu.SetActive(menu.name == _currentMenu);
        }
        MenuChanged?.Invoke();
    }
    
    /// <summary>
    /// Set active new menu from list
    /// </summary>
    /// <param name="newActiveMenu">Menu to activate</param>
    public void SetActiveMenu(GameObject newActiveMenu)
    {
        _currentMenu = newActiveMenu.name;
        foreach (var menuFromMenus in menus)
        {
            menuFromMenus.SetActive(menuFromMenus.name == _currentMenu);
        }
        MenuChanged?.Invoke();
    }



    public void LoadScene()
    {
        //var sceneName = _data.chosenMap;
        //SceneManager.LoadScene(sceneName);
    }
}
