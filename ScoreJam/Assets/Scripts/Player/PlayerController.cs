using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpHeight;
    [SerializeField] private float jumpCheckDistance;
    
    [Space(15)]
    [SerializeField] private float moveSpeed;
    
    private Transform _orientation;
    
    private Rigidbody _rb;

    void Start()
    {
        _orientation = Camera.main.transform;
        _rb = GetComponent<Rigidbody>();
        //cmr = GetComponentInChildren<CameraRotating>();
    }

    void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        Move();
        //_rb.velocity += new Vector3(cmr.movement.x * moveSpeed, 0f, cmr.movement.z * moveSpeed);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 legPosition = transform.position -
                                  new Vector3(0, transform.gameObject.GetComponent<SphereCollider>().radius, 0);
            bool canJump = Physics.Raycast(legPosition, Vector3.down, jumpCheckDistance);
            if (canJump)
            {
                var velocity = _rb.velocity;
                velocity = new Vector3(velocity.x, 0f, velocity.z);
                _rb.velocity = velocity;
                _rb.AddForce(0, jumpHeight, 0, ForceMode.Impulse);
            }
        }
    }

    private void Move()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            Vector3 movement = new Vector3();

            float vertical = Input.GetAxis("Vertical");
            float horizontal = Input.GetAxis("Horizontal");
            
            movement += _orientation.forward * vertical;
            movement += _orientation.right * horizontal;

            movement *= moveSpeed;

            _rb.AddForce(movement);
        }
    }
}
