using System.Collections.Generic;
using ShootEmBounce.Scripts.Data;
using ShootEmBounce.Scripts.Player;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [Folder, SerializeField] private Object weaponSOFolder;

    private DataManager _dataManager;

    private void Awake()
    {
        _dataManager = FindObjectOfType<DataManager>();

        Weapon[] weapons = Resources.LoadAll<Weapon>(weaponSOFolder.name);
        foreach (var weapon in weapons)
        {
            if (weapon.id == _dataManager.playerData.chosenWeaponID)
            {
                Instantiate(weapon.weaponPrefab, GameObject.FindWithTag("MainCamera").transform);
            }
        }
        
        InitializeWeapon();
    }

    private void InitializeWeapon()
    {
        /*foreach (var weapon in weapons)
        {
            /*if (weapon.name != _data.chosenWeapon)
            {
                weapon.SetActive(false);
            }
            else
            {
                weapon.SetActive(true);
            }#1#
        }*/
    }
}
