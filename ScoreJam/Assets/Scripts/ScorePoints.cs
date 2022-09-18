using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScorePoints : MonoBehaviour
{
    static ScorePoints instance;
    public int score { get; private set; }
    private TextMeshProUGUI scoreText;

    [SerializeField] private TextMeshProUGUI scoreMultiplierText;
    [SerializeField] private int comboCount = 5;
    [SerializeField] private Color[] scoreColors;
    private int curComboCount = 0;
    [SerializeField] private float comboTime = 3f;
    private float comboTimer = 0f;
    private bool comboInProgress = false;

    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        instance = this;
        score = 0;
        instance.scoreText.text = "Score: " + instance.score;
    }

    static public void UpdateScore()
    {
        if (instance != null)
        {
            if (!instance.comboInProgress )
            {
                instance.curComboCount++;
                instance.comboInProgress = true;
            }
            else if (instance.curComboCount < instance.comboCount)
            {
                instance.curComboCount++;
            }
            instance.comboTimer = 0f;
            instance.score += 100 * instance.curComboCount;
            instance.scoreText.text = instance.score.ToString();
        }
    }

    private void Update()
    {
        ComboUpdater();
        
        if (comboInProgress)
        {
            comboTimer += Time.deltaTime;

            if (comboTimer >= comboTime)
                EndOfCombo();
        }

    }

    private void ComboUpdater()
    {
        if (instance.curComboCount == 0)
        {
            instance.scoreMultiplierText.text = "x" + 1;
            instance.scoreMultiplierText.color = instance.scoreColors[0];
        }
        else
        {
            instance.scoreMultiplierText.text = "x" + instance.curComboCount;
            instance.scoreMultiplierText.color = instance.scoreColors[instance.curComboCount-1];
        }
    }

    private void EndOfCombo()
    {
        comboInProgress = false;
        curComboCount = 0;
        comboTimer = 0f;
    }
}
