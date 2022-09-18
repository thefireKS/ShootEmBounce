using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAmmo : MonoBehaviour
{
    [SerializeField] private int maxCollision = 1;
    private int currentCollision = 0;
    void OnCollisionEnter(Collision other)
    {
        currentCollision++;
        if(currentCollision == maxCollision)
        {
            Destroy(gameObject);
        }
    }
}
