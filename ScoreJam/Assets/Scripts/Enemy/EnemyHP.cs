using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    
    private float _currentHealth;

    private void Awake()
    {
        _currentHealth = maxHealth;
    }

    
    
    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        CheckHealth();
    }

    private void CheckHealth()
    {
        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        ScorePoints.UpdateScore();
    }
}
