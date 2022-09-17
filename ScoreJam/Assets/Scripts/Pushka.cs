using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushka : MonoBehaviour
{
    [SerializeField] private GameObject tochka;
    [SerializeField] private GameObject ammo;
    [SerializeField] private float fireForce;
    [SerializeField] private float delay;
    private bool allowFire = true;
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0) && allowFire)
        {
            StartCoroutine(Fire());
        }
    }

    private IEnumerator Fire()
    {
        allowFire = false;
        Vector3 spawnPoint = tochka.transform.position;
        Quaternion spawnRoot = tochka.transform.rotation;
        GameObject firedAmmo = Instantiate(ammo, spawnPoint, spawnRoot) as GameObject;
        Rigidbody firedAmmo_rb = firedAmmo.GetComponent<Rigidbody>();
        firedAmmo_rb.AddForce(firedAmmo.transform.forward * fireForce, ForceMode.Impulse);
        yield return new WaitForSeconds(delay);
        allowFire = true;
    }
}
