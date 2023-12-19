using System.Collections.Generic;
using ShootEmBounce.Scripts.Player;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> weapons;

    private Data _data;

    private void Start()
    {
        //_data = FindObjectOfType<Data>();
        
        InitializeWeapon();
    }

    private void InitializeWeapon()
    {
        foreach (var weapon in weapons)
        {
            /*if (weapon.name != _data.chosenWeapon)
            {
                weapon.SetActive(false);
            }
            else
            {
                weapon.SetActive(true);
            }*/
        }
    }
}
