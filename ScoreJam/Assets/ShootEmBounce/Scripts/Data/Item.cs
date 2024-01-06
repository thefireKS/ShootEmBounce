using System;
using UnityEngine;
using UnityEngine.Localization;

namespace ShootEmBounce.Scripts.Data
{
    public abstract class Item : ScriptableObject
    {
        public int id { get; private set; }
        public LocalizedString itemName;
        public LocalizedString itemDescription;
        public Sprite previewImage;
        public uint itemCost;
        
        private void OnEnable()
        {
            // Генерируем ID только при первом включении объекта
            if (id == 0)
            {
                id = GenerateUniqueID();
            }
        }

        /// <summary>
        /// Generate UID for ITEM by this NAME
        /// </summary>
        /// <returns>Hash</returns>
        private static int GenerateUniqueID()
        {
            return Guid.NewGuid().GetHashCode();
        }
    }
}
