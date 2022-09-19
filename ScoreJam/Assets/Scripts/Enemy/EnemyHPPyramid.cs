using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPPyramid : MonoBehaviour
{
    [SerializeField] private GameObject Parent;
    [SerializeField] private int maxHP;
    private int currentHP;

    private void Awake() {
        currentHP = maxHP;
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Ammo")
        {
            currentHP--;
            if(currentHP == 0)
            {
                Destroy(Parent);
            }
        }
    }

    private void OnDestroy()
    {
        ScorePoints.UpdateScore();
    }
}
