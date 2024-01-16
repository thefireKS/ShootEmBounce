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
            // Проверяем, является ли предмет доступным среди доступного оружия или карт
            return CheckAvailableWeapon(itemId) || CheckAvailableMap(itemId);
        }

        public bool IsItemChosen(int itemId)
        {
            // Проверяем, является ли предмет выбранным среди выбранного оружия или карты
            return chosenWeaponID == itemId || chosenMapID == itemId;
        }

        // Добавляем ID оружия
        public void AddWeaponID(int weaponID)
        {
            availableWeaponsIDs.Add(weaponID);
        }

        // Добавляем ID карты
        public void AddMapID(int mapID)
        {
            availableMapsIDs.Add(mapID);
        }

        public void ChooseItem(Item item)
        {
            // Проверяем, является ли выбранный предмет оружием
            if (item is Weapon weapon)
            {
                chosenWeaponID = weapon.id;
            }
            // Проверяем, является ли выбранный предмет картой
            else if (item is Map map)
            {
                chosenMapID = map.id;
            }

            // Дополнительные действия при выборе предмета, если необходимо
        }
    }
}
