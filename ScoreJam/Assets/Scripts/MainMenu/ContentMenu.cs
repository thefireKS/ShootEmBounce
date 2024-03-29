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

    public List<Content> contents;
    public int currentContent;

    private void Start()
    {
        UpdateContent();
    }

    private void UpdateContent()
    {
        var content = contents[currentContent];
        contentPreviewImage.sprite = content.contentPreview;
        contentNameText.text = content.contentName;
        contentDescriptionText.text = content.contentDescription;
    }

    public void ChangeContentBy(int step)
    {
        currentContent += step;
        
        if (currentContent >= contents.Count)
        {
            currentContent = 0;
        }

        if (currentContent < 0)
        {
            currentContent = contents.Count - 1;
        }
        
        UpdateContent();
    }

    public Content ReturnCurrent()
    {
        return contents[currentContent];
    }

    public void ChoseWeapon()
    {
        PlayerData _playerData = FindObjectOfType<PlayerData>();
        _playerData.ChangeWeapon(contents[currentContent].contentName);
    }
    
    public void ChoseMap()
    {
        PlayerData _playerData = FindObjectOfType<PlayerData>();
        _playerData.ChangeMap(contents[currentContent].contentName);
    }

    
}
