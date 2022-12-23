using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blow : MonoBehaviour
{
    [SerializeField] private AudioSource blowSound;
    [SerializeField] private GameObject boomVFX;
    private static List<GameObject> GOinTrigger = new List<GameObject>();
    private bool _bam;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy")) GOinTrigger.Add(other.gameObject);
    }

    void OnTriggerExit(Collider other)
    {
        GOinTrigger.Remove(other.gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!_bam)
        {
            StartCoroutine(BOM());
            _bam = !_bam;
        }
    }

    private IEnumerator BOM()
    {
        foreach (var t in GOinTrigger)
        {
            if(t)
            {
                Destroy(t);
            }
        }
        blowSound.Play();
        Instantiate(boomVFX, transform.position, Quaternion.Euler(0,0,0));
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
