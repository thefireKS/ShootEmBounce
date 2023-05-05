using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private int _currentMoney;

    private void Start()
    {
        DontDestroyOnLoad(this);
        
        Initialization();
    }

    private void Initialization()
    {
        // Set money by player data
        if (PlayerPrefs.HasKey("money"))
        {
            _currentMoney = PlayerPrefs.GetInt("money");
        }
        else
        {
            PlayerPrefs.SetInt("money", 0);
        }
    }

    public void ChangeMoney(int value)
    {
        _currentMoney += value;
        PlayerPrefs.SetInt("money", _currentMoney);
    }
}
