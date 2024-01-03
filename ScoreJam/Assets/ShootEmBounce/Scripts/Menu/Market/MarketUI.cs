using ShootEmBounce.Scripts.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MarketUI : MonoBehaviour
{
    public TextMeshProUGUI itemNameText;
    public TextMeshProUGUI itemDescriptionText;
    public TextMeshProUGUI itemCostText;

    private MarketLogic marketLogic;

    private void Start()
    {
        marketLogic = GetComponent<MarketLogic>();
        ShowCurrentItem();
    }

    private void ShowCurrentItem()
    {
        Item currentItem = marketLogic.GetCurrentItem();
        if (currentItem != null)
        {
            itemNameText.text = currentItem.itemName.GetLocalizedString();
            itemDescriptionText.text = currentItem.itemDescription.GetLocalizedString();
            itemCostText.text = $"Cost: {currentItem.itemCost}";
        }
    }

    public void SwitchToNextItem()
    {
        marketLogic.SwitchToNextItem();
        ShowCurrentItem();
    }

    public void SwitchToPreviousItem()
    {
        marketLogic.SwitchToPreviousItem();
        ShowCurrentItem();
    }

    public void BuyCurrentItem()
    {
        marketLogic.BuyCurrentItem();
        // Дополнительные действия при покупке (например, обновление интерфейса)
    }
}