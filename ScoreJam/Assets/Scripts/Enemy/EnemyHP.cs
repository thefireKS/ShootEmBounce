using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] private int maxHitPoints;
    private Rigidbody _rb;
    private int _currentHp;
    
    private GameObject lastCollided;
    private Vector3 lastVelocity, direction, summary;
    private float speed;

    private void Awake()
    {
        _currentHp = maxHitPoints;
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        lastVelocity = _rb.velocity;
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ammo"))
        {
            _currentHp--;
            if(_currentHp == 0)
            {
                Destroy(gameObject);
            }
        }
        lastCollided = other.gameObject;

            if (lastVelocity.magnitude < 20f)
                speed = lastVelocity.magnitude;
            direction = Vector3.Reflect(lastVelocity.normalized, other.contacts[0].normal);
            summary = direction * Mathf.Max(speed, 0f) * 1.05f;
            _rb.velocity = new Vector3(Mathf.Min(summary.x, 20f), Mathf.Min(_rb.velocity.y,20f), Mathf.Min(summary.z, 20f));
    }

    private void OnDestroy()
    {
        ScorePoints.UpdateScore();
    }
}
