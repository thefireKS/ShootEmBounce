using System;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private int _currentMoney;
    
    public string chosenArena;
    public string availableMaps;

    private void Start()
    {
        DontDestroyOnLoad(this);
        
        Initialization();
    }

    private void Initialization()
    {
        // Set money by player data
        if (!PlayerPrefs.HasKey("money"))
        {
            PlayerPrefs.SetInt("money", 0);
        }
        
        _currentMoney = PlayerPrefs.GetInt("money");
        
        // Set map by player data
        if (!PlayerPrefs.HasKey("map"))
        {
            PlayerPrefs.SetString("map", "Toy Machine");
        }
        
        chosenArena = PlayerPrefs.GetString("map");
        
        // Set available maps by player data
        if (!PlayerPrefs.HasKey("maps"))
        {
            PlayerPrefs.SetString("maps", "Toy Machine");
        }

        availableMaps = PlayerPrefs.GetString("maps");
    }

    public void ChangeMoney(int value)
    {
        _currentMoney += value;
        PlayerPrefs.SetInt("money", _currentMoney);
    }

    public int ReturnCurrentMoney()
    {
        return _currentMoney;
    }

    public void ChangeMap(string map)
    {
        chosenArena = map;
        PlayerPrefs.SetString("map", map);
    }

    public void ChangeAvailableContent(string contentType, string contentName)
    {
        if (contentType == "maps")
        {
            ChangeAvailableMaps(contentName);
            return;
        }

        if (contentType == "weapons")
        {
            //ChangeAvailableMaps(contentName);
            return;
        }
    }
    public void ChangeAvailableMaps(string mapToAdd)
    {
        availableMaps += mapToAdd;
        PlayerPrefs.SetString("maps", availableMaps);
    }
}
