using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class EndGameScoreUpload : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI totalScore;

    [SerializeField] private ScoreManager scoreManager;

    private string _leaderboardKey = "highscoreBoard";
}
