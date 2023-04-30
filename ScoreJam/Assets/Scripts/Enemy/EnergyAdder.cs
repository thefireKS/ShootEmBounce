using UnityEngine;

public class EnergyAdder : MonoBehaviour
{
    private Rigidbody _rb;
    
    private Vector3 _lastVelocity, _direction, _summary;
    private float _speed;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    
    private void Update()
    {
        _lastVelocity = _rb.velocity;
    }
    
    void OnCollisionEnter(Collision other)
    {
        if (_lastVelocity.magnitude < 20f)
            _speed = _lastVelocity.magnitude;
        _direction = Vector3.Reflect(_lastVelocity.normalized, other.contacts[0].normal);
        _summary = _direction * Mathf.Max(_speed, 0f) * 1.05f;
        _rb.velocity = new Vector3(Mathf.Min(_summary.x, 20f), Mathf.Min(_rb.velocity.y,20f), Mathf.Min(_summary.z, 20f));
    }
}
