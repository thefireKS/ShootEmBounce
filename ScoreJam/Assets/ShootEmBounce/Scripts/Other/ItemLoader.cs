using ShootEmBounce.Scripts.Data;
using UnityEditor;
using UnityEngine;

public class ItemLoader
{
    public Item[] LoadItems(Object folderObject)
    {
        if (folderObject != null)
        {
            string folderPath = folderObject.name;
            return Resources.LoadAll<Item>(folderPath);
        }
        else
        {
            Debug.LogError("Папка не указана!");
            return null;
        }
    }
}