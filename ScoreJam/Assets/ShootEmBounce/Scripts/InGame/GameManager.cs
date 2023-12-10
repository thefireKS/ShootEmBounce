using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float timeToPlay;

    private GameObject _endMenu;
    private TextMeshProUGUI _endGameText;
        
    private float _timer;
    private float _minutes, _seconds;
    private bool _isEnd = true;

    private TextMeshProUGUI _timerText;

    private ScoreManager _scoreManager;

    private void Start()
    {
        _timerText = GameObject.Find("TimerText").GetComponent<TextMeshProUGUI>();
        _endMenu = GameObject.Find("End Menu");
        _endGameText = GameObject.Find("EndGameText").GetComponent<TextMeshProUGUI>();
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
        SceneManager.LoadScene("Main Menu");
    }

    private void OpenEndMenu()
    {
        _endGameText.text = $"Your score: {_scoreManager.ReturnScore()}";
        Cursor.lockState = CursorLockMode.Confined;
        GameObject.Find("Timer").SetActive(false);
        GameObject.Find("Score").SetActive(false);
        Cursor.visible = true;
        FindObjectOfType<AudioListener>().enabled = false;
        
        _endMenu.GetComponent<Canvas>().enabled = true;
    }

    private void EndGame()
    {
        Time.timeScale = 0f;
        OpenEndMenu();
    }
}
