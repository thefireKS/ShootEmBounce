using ShootEmBounce.Scripts.Player;
using UnityEngine;
using YG;

namespace ShootEmBounce.Scripts.Other
{
    public class Bootstrap : MonoBehaviour
    {
        private void OnEnable() => YandexGame.GetDataEvent += GetLoad;
        private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;
        
        public void GetLoad()
        {
            DataManager playerDataManager = FindObjectOfType<DataManager>();
            playerDataManager.playerData = YandexGame.savesData.playerData;
        }
    }
}
