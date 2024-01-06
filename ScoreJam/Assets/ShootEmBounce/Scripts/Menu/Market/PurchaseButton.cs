// PurchaseButton.cs
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization;

public class PurchaseButton : MonoBehaviour
{
    public LocalizedString buyLocalizedString;
    public LocalizedString selectLocalizedString;
    public LocalizedString selectedLocalizedString;

    private Button button;
    private MarketLogic marketLogic;

    private void Start()
    {
        button = GetComponent<Button>();
        marketLogic = GetComponentInParent<MarketLogic>();
        UpdateButton();
    }

    public void UpdateButton()
    {
        ItemStatus status = marketLogic.GetItemStatus();  // Теперь используем метод из MarketLogic

        LocalizedString buttonText = GetLocalizedButtonText(status);

        SetButtonStyle(buttonText, status != ItemStatus.PurchasedSelected);
    }

    private LocalizedString GetLocalizedButtonText(ItemStatus status)
    {
        switch (status)
        {
            case ItemStatus.NotPurchased:
                return buyLocalizedString;
            case ItemStatus.PurchasedNotSelected:
                return selectLocalizedString;
            case ItemStatus.PurchasedSelected:
                return selectedLocalizedString;
            default:
                return new LocalizedString();
        }
    }

    private void SetButtonStyle(LocalizedString buttonText, bool interactable)
    {
        button.interactable = interactable;
        UpdateText(buttonText.GetLocalizedString());
    }

    private void UpdateText(string localizedString)
    {
        button.GetComponentInChildren<Text>().text = localizedString;
    }

    public void OnButtonClick()
    {
        marketLogic.OnButtonClick();  // Вызываем метод из MarketLogic при нажатии кнопки
    }
}

public enum ItemStatus
{
    NotPurchased,
    PurchasedNotSelected,
    PurchasedSelected
}
