using System;
using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject[] gunDots;
    [SerializeField] private GameObject ammo;
    [SerializeField] private float fireForce;
    [SerializeField] private float delay;
    [SerializeField] private ParticleSystem particleSystem;
    private float currentTime = 0f;
    private bool _allowFire = true;
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0) && _allowFire)
        {
            Shooting();
            _allowFire = false;
        }
    }

    private void FixedUpdate()
    {
        if (_allowFire == false)
        {
            currentTime += Time.fixedDeltaTime;
            if (currentTime > delay)
            {
                _allowFire = true;
                currentTime = 0f;
            }
        }
    }

    private void Shooting()
    {
        particleSystem.Play();
        foreach (var gunDot in gunDots)
        {
            Vector3 spawnPoint = gunDot.transform.position;
            Quaternion spawnRoot = gunDot.transform.rotation;
            GameObject firedAmmo = Instantiate(ammo, spawnPoint, spawnRoot);
            Rigidbody firedAmmoRb = firedAmmo.GetComponent<Rigidbody>();
            firedAmmoRb.AddForce(firedAmmo.transform.forward * fireForce, ForceMode.Impulse);
        }
    }
}
