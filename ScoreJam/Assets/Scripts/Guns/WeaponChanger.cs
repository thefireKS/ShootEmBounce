using UnityEngine;

public class WeaponChanger : MonoBehaviour
{
    [SerializeField ] private GameObject[] weapons;
    private int _weaponInOrder;
    private void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            weapons[_weaponInOrder].gameObject.SetActive(false);
            _weaponInOrder++;
            if (_weaponInOrder == weapons.Length)
            {
                _weaponInOrder = 0;
            }
            weapons[_weaponInOrder].gameObject.SetActive(true);
        }
    }
}
