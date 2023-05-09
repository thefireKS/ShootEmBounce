using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float timeToPlay;
    private float _timer;

    private ScoreManager _scoreManager;

    private void Start()
    {
        _scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void FixedUpdate()
    {
        _timer += Time.fixedDeltaTime;
        if (_timer > timeToPlay)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        _scoreManager.AddMoney();
        SceneManager.LoadScene("Main Menu");
    }
}
