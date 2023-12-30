using TMPro;
using UnityEngine;

public class ConfirmText : MonoBehaviour
{
    [SerializeField] private ContentMenu contentMenu;
    private TextMeshProUGUI _buttonText;

    private void Start()
    {
        _buttonText = GetComponent<TextMeshProUGUI>();
        UpdateState();
    }

    public void UpdateState()
    {
        if (contentMenu.contents[contentMenu.currentContent].contentName == PlayerPrefs.GetString("weapon"))
        {
            _buttonText.text = "CONFIRMED";
        }
        else
        {
            _buttonText.text = "CONFIRM";
        }
    }
}
