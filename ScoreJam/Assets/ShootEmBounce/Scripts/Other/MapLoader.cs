using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ShootEmBounce.Scripts.Other
{
    public class MapLoader : MonoBehaviour
    {
        public static MapLoader Instance;

        private void Awake()
        {
            if (Instance == null) Instance = this;
        }

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public void LoadMainMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}
