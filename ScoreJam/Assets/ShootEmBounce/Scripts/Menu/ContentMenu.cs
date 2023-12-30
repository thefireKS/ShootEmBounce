using System;
using System.Collections.Generic;
using ShootEmBounce.Scripts.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ContentMenu : MonoBehaviour
{
    [Serializable]
    public struct Content
    {
        public Sprite contentPreview;
        [Multiline] public string contentDescription;
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
        //Data data = FindObjectOfType<Data>();
        //data.ChangeWeapon(contents[currentContent].contentName);
    }
    
    public void ChoseMap()
    {
        //Data data = FindObjectOfType<Data>();
        //data.ChangeMap(contents[currentContent].contentName);
    }

    
}
