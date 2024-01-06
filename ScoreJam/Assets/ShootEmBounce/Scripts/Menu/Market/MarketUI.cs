using ShootEmBounce.Scripts.Data;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

public class MarketUI : MonoBehaviour
{
    public LocalizeStringEvent itemNameText;
    public LocalizeStringEvent itemDescriptionText;
    public TextMeshProUGUI itemCostText;
    public Image itemImage;

    [SerializeField] private MarketLogic marketLogic;

    private void Start()
    {
        if(marketLogic == null) marketLogic = GetComponent<MarketLogic>();
        ShowCurrentItem();
    }

    private void ShowCurrentItem()
    {
        Item currentItem = marketLogic.GetCurrentItem();
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
        marketLogic.OnButtonClick();
        // Дополнительные действия при покупке (например, обновление интерфейса)
    }
}