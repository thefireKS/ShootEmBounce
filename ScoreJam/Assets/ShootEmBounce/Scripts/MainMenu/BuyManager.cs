using ShootEmBounce.Scripts.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyManager : MonoBehaviour
{
    private Data _data;
    [SerializeField] private string buyType; // PlayerPref key

    [SerializeField] private ContentMenu contentMenu;
    [SerializeField] private TextMeshProUGUI statusText;

    [SerializeField] private Button buyButton;
    [SerializeField] private GameObject applyButton;

    [SerializeField] private TextMeshProUGUI moneyText;

    private void Start()
    {
        //_data = FindObjectOfType<Data>();
        
        UpdateStatus();
        ChangeMoneyText();
    }

    public void UpdateStatus()
    {
        var contentName = contentMenu.ReturnCurrent().contentName;
        var availableContent = PlayerPrefs.GetString(buyType);

        if (availableContent.Contains(contentName))
        {
            statusText.text = "BOUGHT";
            buyButton.enabled = false;
            applyButton.SetActive(true);
        }
        else
        {
            statusText.text = "BUY";
            buyButton.enabled = true;
            applyButton.SetActive(false);
        }
    }

    public void BuyContent()
    {
        var currentContent = contentMenu.ReturnCurrent();

        /*if (_data.ReturnCurrentMoney() >= currentContent.price)
        {
            _data.ChangeMoney(-currentContent.price);
            ChangeMoneyText();
            _data.ChangeAvailableContent(buyType, currentContent.contentName);
            UpdateStatus();
            Debug.Log($"The player bought {currentContent.contentName}");
        }*/
    }

    public void ChangeMoneyText()
    {
        //moneyText.text = _data.ReturnCurrentMoney().ToString();
    }
}
