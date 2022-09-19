using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private Material[] enemiesMaterial;
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private float radius = 3f;
    [SerializeField] private float delay = 5f;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            GameObject enemy = Instantiate(enemies[i], transform.position + Random.insideUnitSphere * radius, Quaternion.identity);
            enemy.GetComponent<Renderer>().material = enemiesMaterial[Random.Range(0,enemiesMaterial.Length)];
            enemy.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-25, 25), Random.Range(-25, 25), Random.Range(-25, 25));

            if (i == enemies.Length - 1)
                i = 0;

            yield return new WaitForSeconds(delay);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
