using UnityEngine;

public class DeleteAmmo : MonoBehaviour
{
    [SerializeField] private int maxCollision = 1;
    private int _currentCollision = 0;
    void OnCollisionEnter(Collision other)
    {
        _currentCollision++;
        if(_currentCollision == maxCollision)
        {
            Destroy(gameObject);
        }
    }
}
