using System.Threading.Tasks;
using ShootEmBounce.Scripts.Data;
using UnityEditor;
using UnityEngine;

public class ItemLoader
{
    public Task<Item[]> LoadItems(Object folderObject)
    {
        if (folderObject != null)
        {
            string folderPath = folderObject.name;
            return Task.FromResult(Resources.LoadAll<Item>(folderPath));
        }
        else
        {
            Debug.LogError("Папка не указана!");
            return Task.FromResult<Item[]>(null);
        }
    }
}