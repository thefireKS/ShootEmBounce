using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private float radius;
    [SerializeField] private float timeBetweenWaves;

    private float _timer;

    private void FixedUpdate()
    {
        _timer += Time.fixedDeltaTime;
        if (_timer >= timeBetweenWaves)
        {
            Spawn();
            _timer = 0f;
        }
    }

    private void Spawn()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            GameObject enemy = Instantiate(enemies[i], transform.position + Random.insideUnitSphere * radius, Quaternion.identity);
            enemy.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-25, 25), Random.Range(-25, 25), Random.Range(-25, 25));

            if (i == enemies.Length - 1)
                i = 0;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
