using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
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
                ScorePoints.UpdateScore();
                Destroy(gameObject);
            }
        }
    }
}
