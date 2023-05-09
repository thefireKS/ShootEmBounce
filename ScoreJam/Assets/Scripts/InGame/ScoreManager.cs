using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int _currentScore;

    private PlayerData _playerData;

    private void Start()
    {
        _playerData = FindObjectOfType<PlayerData>();
    }

    public void AddScore(int score)
    {
        _currentScore += score;
    }

    public void AddMoney()
    {
        var moneyToAdd = _currentScore / 100;
        _playerData.ChangeMoney(moneyToAdd);
    }
}
