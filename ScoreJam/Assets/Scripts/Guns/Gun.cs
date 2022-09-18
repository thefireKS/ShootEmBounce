using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject[] gunDots;
    [SerializeField] private GameObject ammo;
    [SerializeField] private float fireForce;
    [SerializeField] private float delay;
    private bool _allowFire = true;
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0) && _allowFire)
        {
            StartCoroutine(Fire());
        }
    }

    private IEnumerator Fire()
    {
        _allowFire = false;
        foreach (var gunDot in gunDots)
        {
            Vector3 spawnPoint = gunDot.transform.position;
            Quaternion spawnRoot = gunDot.transform.rotation;
            GameObject firedAmmo = Instantiate(ammo, spawnPoint, spawnRoot);
            Rigidbody firedAmmoRb = firedAmmo.GetComponent<Rigidbody>();
            firedAmmoRb.AddForce(firedAmmo.transform.forward * fireForce, ForceMode.Impulse);
        }
        yield return new WaitForSeconds(delay);
        _allowFire = true;
    }
}
