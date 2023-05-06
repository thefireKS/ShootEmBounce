using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private int _currentMoney;

    public string chosenArena;

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
    }

    public void ChangeMoney(int value)
    {
        _currentMoney += value;
        PlayerPrefs.SetInt("money", _currentMoney);
    }

    public void ChangeMap(string map)
    {
        chosenArena = map;
        PlayerPrefs.SetString("map", map);
    }
}
