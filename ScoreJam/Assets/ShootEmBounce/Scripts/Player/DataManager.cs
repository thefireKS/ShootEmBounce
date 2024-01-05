using UnityEngine;

namespace ShootEmBounce.Scripts.Player
{
    public class DataManager : MonoBehaviour
    {
        public static DataManager Instance;
        public Data playerData;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(gameObject);
            }

        }
    }
}
