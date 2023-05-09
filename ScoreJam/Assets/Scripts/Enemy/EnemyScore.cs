using UnityEngine;

public class EnemyScore : MonoBehaviour
{
    [SerializeField] private int myScore;

    private ScoreManager _scoreManager;

    private void Start()
    {
        _scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnDestroy()
    {
        _scoreManager.AddScore(myScore);
    }
}
