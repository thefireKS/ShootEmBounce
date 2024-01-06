// MarketLogic.cs
using ShootEmBounce.Scripts.Data;
using ShootEmBounce.Scripts.Player;
using UnityEngine;

public class MarketLogic : MonoBehaviour
{
    private ItemLoader itemLoader = new ItemLoader();
    private Item[] availableItems;
    private int currentItemIndex = 0;
    private PurchaseButton purchaseButton;

    public Object itemsFolder;

    private void Start()
    {
        LoadItems();
        purchaseButton = GetComponentInChildren<PurchaseButton>();
        UpdatePurchaseButton();
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
            UpdatePurchaseButton();
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

    public void BuyCurrentItem(Item currentItem)
    {
        if (currentItem != null)
        {
            if (DataManager.Instance.playerData.CheckAvailableItem(currentItem.id)) return;
            if (DataManager.Instance.playerData.currentMoney >= currentItem.itemCost)
            {
                // Достаточно денег, проводим покупку
                DataManager.Instance.playerData.ChangeMoney((int)-currentItem.itemCost); // вычитаем стоимость из денег

                // В зависимости от типа предмета (Weapon или Map) добавляем соответствующий ID в обладаемое
                if (currentItem is Weapon)
                {
                    DataManager.Instance.playerData.AddWeaponID(currentItem.id);
                }
                else if (currentItem is Map)
                {
                    DataManager.Instance.playerData.AddMapID(currentItem.id);
                }

                Debug.Log($"Buying {currentItem.itemName.ToString()} for {currentItem.itemCost} money.");

                // Дополнительные действия по покупке, если необходимо
            }
            else
            {
                Debug.Log("Not enough money to buy this item.");
            }
        }
    }

    public ItemStatus GetItemStatus()
    {
        Item currentItem = GetCurrentItem();

        bool isPurchased = DataManager.Instance.playerData.CheckAvailableItem(currentItem.id);

        bool isSelected = isPurchased && (currentItem.id == DataManager.Instance.playerData.chosenWeaponID || currentItem.id == DataManager.Instance.playerData.chosenMapID);

        if (!isPurchased)
        {
            return ItemStatus.NotPurchased;
        }
        else if (!isSelected)
        {
            return ItemStatus.PurchasedNotSelected;
        }
        else
        {
            return ItemStatus.PurchasedSelected;
        }
    }

    public void OnButtonClick()
    {
        Item currentItem = GetCurrentItem();
        if (currentItem != null)
        {
            ItemStatus status = GetItemStatus();
            switch (status)
            {
                case ItemStatus.NotPurchased:
                    BuyCurrentItem(currentItem);
                    break;
                case ItemStatus.PurchasedNotSelected:
                    // Добавьте логику для выбора предмета
                    break;
            }

            UpdatePurchaseButton();
        }
    }

    private void UpdatePurchaseButton()
    {
        if (purchaseButton != null)
        {
            purchaseButton.UpdateButton();
        }
    }
}
