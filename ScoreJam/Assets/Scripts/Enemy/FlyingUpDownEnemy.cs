using UnityEngine;

public class FlyingUpDownEnemy : MonoBehaviour
{
    [SerializeField] private float speed, upDown, angle;
    private Vector3 _startPosition;
    private bool _isGoingDown;
    private Transform _enemy;
    private void Awake()
    {
        _startPosition = transform.position;
        
    }

    void FixedUpdate()
    {
        if (transform.position.y >= _startPosition.y) _isGoingDown = true;
        transform.Rotate(Vector3.up, angle*Time.fixedDeltaTime);
        if (_isGoingDown)
        {
            transform.position -= new Vector3(0, speed * Time.fixedDeltaTime, 0);
        }
        else
        {
            transform.position += new Vector3(0, speed * Time.fixedDeltaTime, 0);
        }
        if (transform.position.y <= _startPosition.y - upDown) _isGoingDown = false;
    }
}
