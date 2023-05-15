using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int _currentScore;

    private TextMeshProUGUI _scoreText;

    private PlayerData _playerData;
    

    private void Start()
    {
        _scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        UpdateScore(_currentScore);
        _playerData = FindObjectOfType<PlayerData>();
    }

    public void AddScore(int score)
    {
        _currentScore += score;
        UpdateScore(_currentScore);
    }

    private void UpdateScore(int score)
    {
        _scoreText.text = score.ToString();
    }

    public void AddMoney()
    {
        var moneyToAdd = _currentScore / 100;
        _playerData.ChangeMoney(moneyToAdd);
    }

    public int ReturnScore()
    {
        return _currentScore;
    }
}
