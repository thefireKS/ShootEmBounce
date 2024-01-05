using ShootEmBounce.Scripts.Data;
using ShootEmBounce.Scripts.Player;
using UnityEngine;

public class MarketLogic : MonoBehaviour
{
    private ItemLoader itemLoader = new ItemLoader();
    private Item[] availableItems;
    private int currentItemIndex = 0;

    public Object itemsFolder;  // ������ ��� Object

    private void Start()
    {
        LoadItems();
    }

    private void LoadItems()
    {
        availableItems = itemLoader.LoadItems(itemsFolder);
        ShowCurrentItem();
    }

    private void ShowCurrentItem()
    {
        Item currentItem = GetCurrentItem();
        if (currentItem != null)
        {
            Debug.Log($"Showing {currentItem.itemName.GetLocalizedString()} - {currentItem.itemDescription.GetLocalizedString()} (Cost: {currentItem.itemCost})");
        }
    }

    public Item GetCurrentItem()
    {
        return (availableItems != null && availableItems.Length > 0) ? availableItems[currentItemIndex] : null;
    }

    private void ChangeItemIndex(int delta)
    {
        if (availableItems != null && availableItems.Length > 0)
        {
            currentItemIndex = (currentItemIndex + delta + availableItems.Length) % availableItems.Length;
            ShowCurrentItem();
        }
    }

    public void SwitchToNextItem()
    {
        ChangeItemIndex(1);
    }

    public void SwitchToPreviousItem()
    {
        ChangeItemIndex(-1);
    }

    public void BuyCurrentItem()
    {
        Item currentItem = GetCurrentItem();
        if (currentItem != null)
        {
            if (DataManager.Instance.playerData.availableWeaponsIDs.Contains(currentItem.id)) return;
            if (DataManager.Instance.playerData.currentMoney >= currentItem.itemCost)
            {
                // ���������� �����, �������� �������
                DataManager.Instance.playerData.ChangeMoney((int)-currentItem.itemCost); // �������� ��������� �� �����
                DataManager.Instance.playerData.AddWeaponID(currentItem.id); // ��������� ID ������ � ����������
                Debug.Log($"Buying {currentItem.itemName.ToString()} for {currentItem.itemCost} money.");

                // �������������� �������� �� �������, ���� ����������
            }
            else
            {
                Debug.Log("Not enough money to buy this item.");
            }
        }
    }
}