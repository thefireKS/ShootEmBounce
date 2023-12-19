using ShootEmBounce.Scripts.Player;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int _currentScore;

    private TextMeshProUGUI _scoreText;

    private Data _data;
    

    private void Start()
    {
        _scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        UpdateScore(_currentScore);
        //_data = FindObjectOfType<Data>();
    }

    public void AddScore(int score)
    {
        _currentScore += score;
        UpdateScore(_currentScore);
    }

    private void UpdateScore(int score)
    {
        _scoreText.text = $"Score: {score.ToString()}";
    }

    public void AddMoney()
    {
        var moneyToAdd = _currentScore / 100;
        _data.ChangeMoney(moneyToAdd);
    }

    public int ReturnScore()
    {
        return _currentScore;
    }
}
