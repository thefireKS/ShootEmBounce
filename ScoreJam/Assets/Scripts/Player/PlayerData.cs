using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private int _currentMoney;
    
    public string chosenArena;
    public string chosenWeapon;
    
    public string availableMaps;
    public string availableWeapons;

    public string player_id;
    public string playerName;

    private void Awake()
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
        
        // Set weapon by player data
        if (!PlayerPrefs.HasKey("weapon"))
        {
            PlayerPrefs.SetString("weapon", "Nerf Gun");
        }
        
        chosenWeapon = PlayerPrefs.GetString("weapon");
        
        // Set available weapons by player data
        if (!PlayerPrefs.HasKey("weapons"))
        {
            PlayerPrefs.SetString("weapons", "Nerf Gun");
        }

        availableWeapons = PlayerPrefs.GetString("weapons");
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
    
    public void ChangeWeapon(string weapon)
    {
        chosenWeapon = weapon;
        PlayerPrefs.SetString("weapon", weapon);
    }

    public void ChangeAvailableContent(string contentType, string contentName)
    {
        var availableContent = PlayerPrefs.GetString(contentType);
        availableContent += contentName;
        PlayerPrefs.SetString(contentType, availableContent);
    }
}
