using ShootEmBounce.Scripts.Data;
using ShootEmBounce.Scripts.Other;
using ShootEmBounce.Scripts.Player;
using UnityEngine;

namespace ShootEmBounce.Scripts.Menu.Market
{
    public class Logic : MonoBehaviour
    {
        private readonly ItemLoader _itemLoader = new();
        private Item[] _availableItems;
        private int _currentItemIndex = 0;
        [SerializeField] private PurchaseButton purchaseButton;

        public Object itemsFolder;

        private void Awake()
        {
            LoadItems();
            if(purchaseButton == null) purchaseButton = GetComponentInChildren<PurchaseButton>();
            UpdatePurchaseButton();
        }

        private void LoadItems()
        {
            _availableItems = _itemLoader.LoadItems(itemsFolder);
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
            return (_availableItems != null && _availableItems.Length > 0) ? _availableItems[_currentItemIndex] : null;
        }

        private void ChangeItemIndex(int delta)
        {
            if (_availableItems != null && _availableItems.Length > 0)
            {
                _currentItemIndex = (_currentItemIndex + delta + _availableItems.Length) % _availableItems.Length;
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
                    // ���������� �����, �������� �������
                    DataManager.Instance.playerData.ChangeMoney((int)-currentItem.itemCost); // �������� ��������� �� �����

                    // � ����������� �� ���� �������� (Weapon ��� Map) ��������� ��������������� ID � ����������
                    if (currentItem is Weapon)
                    {
                        DataManager.Instance.playerData.AddWeaponID(currentItem.id);
                    }
                    else if (currentItem is Map)
                    {
                        DataManager.Instance.playerData.AddMapID(currentItem.id);
                    }

                    Debug.Log($"Buying {currentItem.itemName.ToString()} for {currentItem.itemCost} money.");

                    // �������������� �������� �� �������, ���� ����������
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

            while(currentItem == null)
            {
                currentItem = GetCurrentItem();
            }

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
                        ChooseItem(currentItem);
                        break;
                }

                UpdatePurchaseButton();
            }
        }

        private void ChooseItem(Item item)
        {
            DataManager.Instance.playerData.ChooseItem(item);

            Debug.Log($"Choosing {item.itemName.ToString()}."); // �������� ���� �����, ����� ���������, ��� ����� �������� ���������
        }


        private void UpdatePurchaseButton()
        {
            if (purchaseButton != null)
            {
                purchaseButton.UpdateButton();
            }
        }

        public void LoadSceneByMap()
        {
            Map map = GetCurrentItem() as Map;

            if (map != null)
            {
                string mapName = map.GetSceneName();
                MapLoader.Instance.LoadScene(mapName);
            }
            else
            {
                Debug.Log("That`s not a map");
            }
        }
    }
}
