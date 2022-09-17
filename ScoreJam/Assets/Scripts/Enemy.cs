using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int id = -1;
    [SerializeField] private GameObject bullet;

    public int GetId() { return id; }

    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        switch (id)
        {
            case 1:
                StartCoroutine(CubeEnemy());
                break;
        }
    }

    private IEnumerator CubeEnemy()
    {
        for (; ; )
        {
            GameObject bul = Instantiate(bullet, transform.position, Quaternion.identity);
            Vector3 direction = player.position - transform.position;
            bul.GetComponent<Rigidbody>().velocity = direction / direction.magnitude * 100f;
            Destroy(bul, 10f);
            yield return new WaitForSeconds(1f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            Debug.Log("Минус хп!");

        else if (collision.gameObject.CompareTag("Bullet"))
            Destroy(gameObject);
    }

    private void OnDestroy()
    {
        ScorePoints.UpdateScore();
    }
}
