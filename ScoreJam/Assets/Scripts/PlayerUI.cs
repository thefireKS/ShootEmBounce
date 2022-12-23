using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    private PlayerHP _playerHp;

    [SerializeField] 
    private Image filler;

    private float _percentage;
    
    // Start is called before the first frame update
    void Start()
    {
        _playerHp = GameObject.FindWithTag("Player").GetComponent<PlayerHP>();
    }

    // Update is called once per frame
    void Update()
    {
        _percentage = (float) _playerHp.currentHP / _playerHp.maxHP;
        filler.fillAmount = _percentage;
    }
}
