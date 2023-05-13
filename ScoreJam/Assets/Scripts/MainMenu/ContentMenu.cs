using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ContentMenu : MonoBehaviour
{
    [Serializable]
    public struct Content
    {
        public Sprite contentPreview;
        public string contentDescription;
        public string contentName;
        public int price;
    }

    [SerializeField] private Image contentPreviewImage;
    [SerializeField] private TextMeshProUGUI contentNameText;
    [SerializeField] private TextMeshProUGUI contentDescriptionText;

    [SerializeField] private List<Content> contents;
    private int _currentContent;

    private void Start()
    {
        UpdateContent();
    }

    private void UpdateContent()
    {
        var content = contents[_currentContent];
        contentPreviewImage.sprite = content.contentPreview;
        contentNameText.text = content.contentName;
        contentDescriptionText.text = content.contentDescription;
    }

    public void ChangeContentBy(int step)
    {
        _currentContent += step;
        
        if (_currentContent >= contents.Count)
        {
            _currentContent = 0;
        }

        if (_currentContent < 0)
        {
            _currentContent = contents.Count - 1;
        }
        
        UpdateContent();
    }

    public Content ReturnCurrent()
    {
        return contents[_currentContent];
    }

    public void ChoseWeapon()
    {
        PlayerData _playerData = FindObjectOfType<PlayerData>();
        _playerData.ChangeWeapon(contents[_currentContent].contentName);
    }
}
