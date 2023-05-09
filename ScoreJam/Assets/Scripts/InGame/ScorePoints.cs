using UnityEngine;
using TMPro;

public class ScorePoints : MonoBehaviour
{
    static ScorePoints instance;
    public int score { get; private set; }
    
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI scoreMultiplierText;
    [SerializeField] private int comboCount = 5;
    [SerializeField] private Color[] scoreColors;
    private int _curComboCount;
    [SerializeField] private float comboTime = 3f;
    private float _comboTimer;
    private bool _comboInProgress;

    private void Start()
    {
        instance = this;
        score = 0;
        instance.scoreText.text = "Score: " + instance.score;
    }

    static public void UpdateScore()
    {
        if (instance != null)
        {
            if (!instance._comboInProgress )
            {
                instance._curComboCount++;
                instance._comboInProgress = true;
            }
            else if (instance._curComboCount < instance.comboCount)
            {
                instance._curComboCount++;
            }
            instance._comboTimer = 0f;
            instance.score += 100 * instance._curComboCount;
            instance.scoreText.text = "Score: " + instance.score;
        }
    }

    private void Update()
    {
        ComboUpdater();
        
        if (_comboInProgress)
        {
            _comboTimer += Time.deltaTime;

            if (_comboTimer >= comboTime)
                EndOfCombo();
        }
    }

    private void ComboUpdater()
    {
        if (instance._curComboCount == 0)
        {
            instance.scoreMultiplierText.text = "x" + 1;
            instance.scoreMultiplierText.color = instance.scoreColors[0];
        }
        else
        {
            instance.scoreMultiplierText.text = "x" + instance._curComboCount;
            instance.scoreMultiplierText.color = instance.scoreColors[instance._curComboCount-1];
        }
    }

    private void EndOfCombo()
    {
        _comboInProgress = false;
        _curComboCount = 0;
        _comboTimer = 0f;
    }
}
