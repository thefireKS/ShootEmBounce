using System;
using System.Collections.Generic;
using ShootEmBounce.Scripts.Data;

namespace ShootEmBounce.Scripts.Player
{
    [Serializable]
    public class Data
    {
        public int currentMoney;
        public int chosenMapID;
        public int chosenWeaponID;

        public List<int> availableMapsIDs;
        public List<int> availableWeaponsIDs;

        public void ChangeMoney(int value)
        {
            currentMoney += value;
        }

        public void ChangeMap(Map map)
        {
            chosenMapID = map.id;
        }

        public void ChangeWeapon(Weapon weapon)
        {
            chosenWeaponID = weapon.id;
        }

        public bool CheckAvailableWeapon(int weaponId)
        {
            return availableWeaponsIDs.Contains(weaponId);
        }

        public bool CheckAvailableMap(int mapId)
        {
            return availableMapsIDs.Contains(mapId);
        }

        public bool CheckAvailableItem(int itemId)
        {
            // ���������, �������� �� ������� ��������� ����� ���������� ������ ��� ����
            return CheckAvailableWeapon(itemId) || CheckAvailableMap(itemId);
        }

        public bool IsItemChosen(int itemId)
        {
            // ���������, �������� �� ������� ��������� ����� ���������� ������ ��� �����
            return chosenWeaponID == itemId || chosenMapID == itemId;
        }

        // ��������� ID ������
        public void AddWeaponID(int weaponID)
        {
            availableWeaponsIDs.Add(weaponID);
        }

        // ��������� ID �����
        public void AddMapID(int mapID)
        {
            availableMapsIDs.Add(mapID);
        }

        public void ChooseItem(Item item)
        {
            // ���������, �������� �� ��������� ������� �������
            if (item is Weapon weapon)
            {
                chosenWeaponID = weapon.id;
            }
            // ���������, �������� �� ��������� ������� ������
            else if (item is Map map)
            {
                chosenMapID = map.id;
            }

            // �������������� �������� ��� ������ ��������, ���� ����������
        }
    }
}
