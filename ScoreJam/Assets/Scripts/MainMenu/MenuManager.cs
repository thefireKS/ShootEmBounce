using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> menus;

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
    }
}
