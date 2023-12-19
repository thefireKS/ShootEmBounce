using UnityEngine;

namespace ShootEmBounce.Scripts.Player
{
    public class DataManager : MonoBehaviour
    {
        public DataManager instance;
        public Data playerData;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(gameObject);
            }

        }
    }
}
