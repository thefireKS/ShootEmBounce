// PurchaseButton.cs
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization;
using TMPro;

public class PurchaseButton : MonoBehaviour
{
    public LocalizedString buyLocalizedString;
    public LocalizedString selectLocalizedString;
    public LocalizedString selectedLocalizedString;

    private Button button;
    [SerializeField] private MarketLogic marketLogic;

    private void Start()
    {
        button = GetComponent<Button>();
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
                Debug.Log("default");
                return new LocalizedString();
        }
    }

    private void SetButtonStyle(LocalizedString buttonText, bool interactable)
    {
        if (button != null)
        {
            button.interactable = interactable;
        }
        else
        {
            Debug.LogError("Button is null. Make sure button is properly initialized.");
        }

        // Проверяем, не является ли buttonText null перед вызовом метода GetLocalizedString
        if (buttonText != null)
        {
            UpdateText(buttonText.GetLocalizedString());
        }
        else
        {
            Debug.LogError("Button text is null. Make sure buttonText is properly initialized.");
        }
    }

    private void UpdateText(string localizedString)
    {
        button.GetComponentInChildren<TextMeshProUGUI>().text = localizedString;
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
