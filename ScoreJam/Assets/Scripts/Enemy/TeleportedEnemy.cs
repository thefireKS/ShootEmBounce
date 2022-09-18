using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class TeleportedEnemy : MonoBehaviour
{
    [SerializeField] private float teleportationDelay, radius;
    private bool _allowTeloportation = true;

    private void Update()
    {
        if(_allowTeloportation) StartCoroutine(Teleport());
    }

    private IEnumerator Teleport()
    {
        transform.position = Random.insideUnitSphere * radius;
        _allowTeloportation = !_allowTeloportation;
        yield return new WaitForSeconds(teleportationDelay);
        _allowTeloportation = !_allowTeloportation;
    }
}
