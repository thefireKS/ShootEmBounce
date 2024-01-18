using ShootEmBounce.Scripts.Data;
using ShootEmBounce.Scripts.Player;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

namespace ShootEmBounce.Scripts.Menu.Market
{
    public class UI : MonoBehaviour
    {
        public LocalizeStringEvent itemNameText;
        public LocalizeStringEvent itemDescriptionText;
        public TextMeshProUGUI itemCostText;
        public TextMeshProUGUI moneyText;
        public Image itemImage;

        [SerializeField] private Logic logic;

        private void Start()
        {
            if(logic == null) logic = GetComponent<Logic>();
            ShowCurrentItem();

            UpdateMoneyText();
        }

        private void UpdateMoneyText()
        {
            moneyText.text = DataManager.Instance.playerData.currentMoney.ToString();
        }

        private void ShowCurrentItem()
        {
            Item currentItem = logic.GetCurrentItem();
            if (currentItem != null)
            {
                itemNameText.StringReference = currentItem.itemName;
                itemDescriptionText.StringReference = currentItem.itemDescription;
                itemImage.sprite = currentItem.previewImage;
                itemCostText.text = $"Cost: {currentItem.itemCost}";
            }
        }

        public void SwitchToNextItem()
        {
            logic.SwitchToNextItem();
            ShowCurrentItem();
        }

        public void SwitchToPreviousItem()
        {
            logic.SwitchToPreviousItem();
            ShowCurrentItem();
        }

        public void BuyCurrentItem()
        {
            logic.OnButtonClick();
            UpdateMoneyText();
            // Дополнительные действия при покупке (например, обновление интерфейса)
        }

        public void LoadSceneByMap()
        {
            logic.LoadSceneByMap();
        }
    }
}