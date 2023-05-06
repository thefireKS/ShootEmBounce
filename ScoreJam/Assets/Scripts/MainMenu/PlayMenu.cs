using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayMenu : MonoBehaviour
{
    [Serializable]
    private struct Map
    {
        public Texture2D mapPreview;
        public string mapDescription;
        public string mapName;
    }

    [SerializeField] private Image mapPreviewImage;
    [SerializeField] private TextMeshProUGUI mapNameText;
    [SerializeField] private TextMeshProUGUI mapDescriptionText;

    [SerializeField] private List<Map> maps;
    private int _currentMap;

}
