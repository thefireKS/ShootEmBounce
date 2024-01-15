using UnityEngine;
using UnityEngine.SceneManagement;

namespace ShootEmBounce.Scripts.Other
{
    public class MapLoader : MonoBehaviour
    {
        public static MapLoader Instance;

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
