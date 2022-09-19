using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] private int maxHP;
    [SerializeField] private Rigidbody rb;
    private int currentHP;
    
    private GameObject lastCollided;
    private Vector3 lastVelocity, direction, summary;
    private float speed;

    private void Awake() {
        currentHP = maxHP;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        lastVelocity = rb.velocity;
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Ammo")
        {
            currentHP--;
            if(currentHP == 0)
            {
                Destroy(gameObject);
            }
        }
        lastCollided = other.gameObject;

            if (lastVelocity.magnitude < 20f)
                speed = lastVelocity.magnitude;
            direction = Vector3.Reflect(lastVelocity.normalized, other.contacts[0].normal);
            summary = direction * Mathf.Max(speed, 0f) * 1.05f;
            rb.velocity = new Vector3(Mathf.Min(summary.x, 20f), Mathf.Min(rb.velocity.y,20f), Mathf.Min(summary.z, 20f));
    }

    private void OnDestroy()
    {
        ScorePoints.UpdateScore();
    }
}
