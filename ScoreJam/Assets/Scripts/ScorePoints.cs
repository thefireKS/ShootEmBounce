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
    
    [SerializeField] private int comboCount = 5;
    private int curComboCount = 0;
    private float comboTime = 10f;
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
                instance.StartCoroutine(instance.ComboTimer());
                instance.score+=100;
            }
            else
            {
                instance.StopCoroutine(instance.ComboTimer());
                instance.StartCoroutine(instance.ComboTimer());
                instance.score += instance.curComboCount * 100;
            }
            instance.scoreText.text = "Score: " + instance.score;
        }
    }

    private IEnumerator ComboTimer()
    {
        if (curComboCount < comboCount)
            curComboCount++;
        comboInProgress = true;
        yield return new WaitForSeconds(comboTime);
        comboInProgress = false;
        curComboCount = 0;
    }
}
