using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int maxHP;
    public int currentHP;
    
    [SerializeField] private float invincibleTime;
    private bool _isInvincible = false;

    private void Awake() {
        currentHP = maxHP;
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Enemy") StartCoroutine(Damage());
    }

    private IEnumerator Damage()
    {
        if(!_isInvincible)
        {
            _isInvincible = true;
            currentHP--;
            if(currentHP == 0)
            {
                Debug.Log("I am DEAD!");
                Time.timeScale = 0f;
            }
        }
        yield return new WaitForSeconds(invincibleTime);
        _isInvincible = false;
    }
}
