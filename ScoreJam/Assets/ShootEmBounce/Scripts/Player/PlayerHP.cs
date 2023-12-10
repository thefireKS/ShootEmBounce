using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int maxHP;
    public int currentHP;
    private bool _isInvincible;
    private float timeForRegen = 0f;
    [SerializeField] private AudioSource ouf;

    [SerializeField] private float invincibleTime;
    [SerializeField] private GameObject endGameUI;
    [SerializeField] private GameObject activeGameUI;
    [SerializeField] private Texture2D cursorTex;
    
    private Vector2 hotSpot = new Vector2(17, 17);
    private void Awake()
    {
        currentHP = maxHP;
        Time.timeScale = 1f;
    }

    private void FixedUpdate()
    {
        timeForRegen += Time.fixedDeltaTime;
        if (currentHP < maxHP && timeForRegen >= 20f)
        {
            currentHP++;
            timeForRegen = 0;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy") StartCoroutine(Damage());
    }

    private IEnumerator Damage()
    {
        if (!_isInvincible)
        {
            timeForRegen = 0;
            _isInvincible = true;
            currentHP--;
            ouf.Play();
            if (currentHP == 0)
            {
                Death();
            }
        }

        yield return new WaitForSeconds(invincibleTime);
        _isInvincible = false;
    }

    private void Death()
    {
        Time.timeScale = 0f;
        endGameUI.SetActive(true);
        activeGameUI.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Cursor.SetCursor(cursorTex, hotSpot, CursorMode.Auto);
    }
}
