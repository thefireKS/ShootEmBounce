// PurchaseButton.cs
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization;
using TMPro;
using UnityEngine.Localization.Components;

public class PurchaseButton : MonoBehaviour
{
    public LocalizedString buyLocalizedString;
    public LocalizedString selectLocalizedString;
    public LocalizedString selectedLocalizedString;

    private LocalizeStringEvent localizeStringEvent;

    private Button button;
    [SerializeField] private MarketLogic marketLogic;

    private void Start()
    {
        button = GetComponent<Button>();
        localizeStringEvent = GetComponentInChildren<LocalizeStringEvent>();
        UpdateButton();
    }

    public void UpdateButton()
    {
        ItemStatus status = marketLogic.GetItemStatus();  // ������ ���������� ����� �� MarketLogic

        Debug.Log(status.ToString());

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

        // ���������, �� �������� �� buttonText null ����� ������� ������ GetLocalizedString
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
        localizeStringEvent.StringReference = localizedString;
    }

    public void OnButtonClick()
    {
        marketLogic.OnButtonClick();  // �������� ����� �� MarketLogic ��� ������� ������
    }
}

public enum ItemStatus
{
    NotPurchased,
    PurchasedNotSelected,
    PurchasedSelected
}
