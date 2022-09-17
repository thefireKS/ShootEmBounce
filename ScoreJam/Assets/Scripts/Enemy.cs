using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int id = -1;

    [SerializeField] private GameObject bullet;

    public int GetId() { return id; }

    private void Update()
    {
        switch (id) {
            case 0:
                break;
            case 1:
                StartCoroutine(CubeEnemy());
                break;
        }
    }

    private IEnumerator CubeEnemy()
    {
        GameObject bul = Instantiate(bullet, transform.position, Quaternion.identity);
        bul.GetComponent<Rigidbody>().velocity = transform.forward * 40f;
        Destroy(bul, 5f);
        yield return new WaitForSeconds(1f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            Debug.Log("Минус хп!");
        
        else if (collision.gameObject.CompareTag("Bullet"))
            Destroy(gameObject);
    }
}
