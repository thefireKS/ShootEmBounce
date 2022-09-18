using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blow : MonoBehaviour
{
    [SerializeField] private float blowDelay;

    private SphereCollider blowCollider;

    public static List<GameObject> GOinTrigger = new List<GameObject>();

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy") GOinTrigger.Add(other.gameObject);
    }

    void OnTriggerExit(Collider other)
    {
        GOinTrigger.Remove(other.gameObject);
    }
    // Start is called before the first frame update
    private void Awake()
    {
        StartCoroutine(BOM());
    }

    private IEnumerator BOM()
    {
        SphereCollider[] spheres = GetComponents<SphereCollider>();
        for(int i = 0; i < spheres.Length; i++)
        {
            if(spheres[i].isTrigger == true)
            {
                blowCollider = spheres[i];
            }
        }
        yield return new WaitForSeconds(blowDelay);
        for (int i = 0; i < GOinTrigger.Count; i++)
        {
            if(GOinTrigger[i])
            {
                Destroy(GOinTrigger[i]);
            }
        }
        Destroy(gameObject);
    }
}
