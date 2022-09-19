using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPyramids : MonoBehaviour
{
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
