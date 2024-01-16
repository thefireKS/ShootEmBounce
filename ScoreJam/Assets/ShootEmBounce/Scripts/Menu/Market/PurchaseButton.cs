// PurchaseButton.cs

using ShootEmBounce.Scripts.Menu.Market;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization;
using TMPro;
using UnityEngine.Localization.Components;
using UnityEngine.Serialization;

public class PurchaseButton : MonoBehaviour
{
    public LocalizedString buyLocalizedString;
    public LocalizedString selectLocalizedString;
    public LocalizedString selectedLocalizedString;

    private LocalizeStringEvent _localizeStringEvent;

    private Button _button;
    [SerializeField] private Logic logic;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _localizeStringEvent = GetComponentInChildren<LocalizeStringEvent>();
        UpdateButton();
    }

    public void UpdateButton()
    {
        ItemStatus status = logic.GetItemStatus();  // Теперь используем метод из MarketLogic

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
        if (_button != null)
        {
            _button.interactable = interactable;
        }
        else
        {
            Debug.LogError($"{gameObject.name}: Button is null. Make sure button is properly initialized.");
            return;
        }

        // Проверяем, не является ли buttonText null перед вызовом метода GetLocalizedString
        if (buttonText != null)
        {
            UpdateText(buttonText);
        }
        else
        {
            Debug.LogError("Button text is null. Make sure buttonText is properly initialized.");
        }
    }

    private void UpdateText(LocalizedString localizedString)
    {
        _localizeStringEvent.StringReference = localizedString;
    }

    public void OnButtonClick()
    {
        logic.OnButtonClick();  // Вызываем метод из MarketLogic при нажатии кнопки
    }
}

public enum ItemStatus
{
    NotPurchased,
    PurchasedNotSelected,
    PurchasedSelected
}
