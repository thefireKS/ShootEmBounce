using ShootEmBounce.Scripts.Other;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float timeToPlay;
        
    private float _timer;
    private float _minutes, _seconds;
    private bool _isEnd = true;

    private TextMeshProUGUI _timerText;

    private ScoreManager _scoreManager;

    private void Start()
    {
        _timerText = GameObject.Find("TimerText").GetComponent<TextMeshProUGUI>();
        _timer = timeToPlay;
        UpdateTimer();
        _scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void FixedUpdate()
    {
        _timer -= Time.fixedDeltaTime;
        
        UpdateTimer();

        if (_timer <= 0)
        {
            if(_isEnd)EndGame();
            _isEnd = false;
        }
    }

    private void UpdateTimer()
    {
        if (_timer < 0) return;
        _minutes = Mathf.FloorToInt(_timer / 60);
        _seconds = Mathf.FloorToInt(_timer % 60);
        _timerText.text = $"{_minutes:00}:{_seconds:00}";
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        _scoreManager.AddMoney();
        MapLoader.LoadMainMenu();
    }

    private void EndGame()
    {
        Time.timeScale = 0f;
        ReturnToMenu();
    }
}
