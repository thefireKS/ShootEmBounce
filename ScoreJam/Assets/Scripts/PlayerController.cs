using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpHeight;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxSpeed;
    
    private Rigidbody rb;
    private CameraRotating cmr;
    
    private Vector3 lastVelocity, direction, summary;

    private bool jumpPressed, canJump = true;

    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cmr = GetComponentInChildren<CameraRotating>();
    }

    void Update()
    {
        lastVelocity = rb.velocity;
        Inputs();
    }

    private void FixedUpdate()
    {
        if (jumpPressed && canJump)
        {
            rb.AddForce(0,jumpHeight,0,ForceMode.Impulse);
            Debug.Log("Lets gooo");
            canJump = false;
        }
        //rb.velocity += new Vector3(cmr.movement.x * moveSpeed, 0f, cmr.movement.z * moveSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (lastVelocity.magnitude < maxSpeed)
            speed = lastVelocity.magnitude;
        else
            return;
        direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
        summary = direction * Mathf.Max(speed, 0f) * 1.02f;
        rb.velocity = new Vector3(Mathf.Min(summary.x, maxSpeed), rb.velocity.y, Mathf.Min(summary.z, maxSpeed));

        if (collision.gameObject.CompareTag("Floor"))
            canJump = true;
    }

    private void Inputs()
    {
        jumpPressed = Input.GetKey(KeyCode.Space);
    }
}
