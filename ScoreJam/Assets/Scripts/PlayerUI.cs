using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    private PlayerHP php;

    [SerializeField] 
    private Image filler;

    private float percentage;
    
    // Start is called before the first frame update
    void Start()
    {
        php = GameObject.FindWithTag("Player").GetComponent<PlayerHP>();
    }

    // Update is called once per frame
    void Update()
    {
        percentage = (float) php.currentHP / php.maxHP;
        filler.fillAmount = percentage;
    }
}
