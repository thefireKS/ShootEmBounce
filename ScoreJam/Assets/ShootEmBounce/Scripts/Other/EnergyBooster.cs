using UnityEngine;

public class EnergyBooster : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float maxSpeed;
    
    [SerializeField][Range(0,1)] private float decelerationFactor;
    [SerializeField][Range(1,1000)] private float accelerationFactor;

    private Vector3 _lastVelocity;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _lastVelocity = _rb.velocity;
    }

    private void FixedUpdate()
    {
        ControlSpeed();
    }

    private void OnCollisionEnter(Collision collision)
    {
        AddSpeed(collision);
    }

    private void AddSpeed(Collision collision)
    {
        float speed;
        if (_rb.velocity.magnitude < maxSpeed)
        {
            speed = _lastVelocity.magnitude;
        }
        else
        {
            return;
        }

        Vector3 direction = Vector3.Reflect(_lastVelocity.normalized, collision.contacts[0].normal);
        direction = direction * speed * accelerationFactor;
        _rb.AddForce(direction, ForceMode.Impulse);
    }

    private void ControlSpeed()
    {
        if (_rb.velocity.magnitude > maxSpeed)
        {
            _rb.velocity *= decelerationFactor;
        }
    }
}
