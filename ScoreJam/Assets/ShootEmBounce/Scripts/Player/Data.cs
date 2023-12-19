using System;
using System.Collections.Generic;
using ShootEmBounce.Scripts.Data;

namespace ShootEmBounce.Scripts.Player
{
    [Serializable]
    public class Data
    {
        public int currentMoney { get; private set; }
    
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
    }
}
