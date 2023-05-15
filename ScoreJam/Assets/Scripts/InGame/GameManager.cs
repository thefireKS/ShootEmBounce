using LootLocker.Requests;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float timeToPlay;
    private float _timer;
    private bool _isEnd = true;
    
    [SerializeField] private string leaderboardKey;

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
            if(_isEnd)EndGame();
            _isEnd = false;
        }
    }
    
    public void UploadScore()
    {
        LootLockerSDKManager.GetPlayerName(response =>
        {
            Debug.Log(_scoreManager.ReturnScore());
            LootLockerSDKManager.SubmitScore(FindObjectOfType<PlayerData>().player_id, _scoreManager.ReturnScore(), "TotalLeaderboard", response.name, (lootLockerSubmitScoreResponse) => {});
            LootLockerSDKManager.SubmitScore(FindObjectOfType<PlayerData>().player_id, _scoreManager.ReturnScore(), leaderboardKey, response.name, (response) =>
            {
                if (response.success)
                {
                    _scoreManager.AddMoney();
                    SceneManager.LoadScene("Main Menu");
                }
            });
        });
        
    }

    private void EndGame()
    {
        UploadScore();
    }
}
