using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> weapons;

    private PlayerData _playerData;

    private void Start()
    {
        _playerData = FindObjectOfType<PlayerData>();
        
        InitializeWeapon();
    }

    private void InitializeWeapon()
    {
        foreach (var weapon in weapons)
        {
            if (weapon.name != _playerData.chosenWeapon)
            {
                weapon.SetActive(false);
            }
        }
    }
}
