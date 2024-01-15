using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ShootEmBounce.Scripts.Data
{
    [CreateAssetMenu(fileName = "SO_Map_MapName", menuName = "Data/Map")]
    public class Map : Item
    {
        [SerializeField] private Object mapScene;

        public string GetSceneName()
        {
            string assetPath = AssetDatabase.GetAssetPath(mapScene);
            
            return System.IO.Path.GetFileNameWithoutExtension(assetPath);
        }

        private void OnValidate()
        {
            if (mapScene != null)
            {
                string assetPath = AssetDatabase.GetAssetPath(mapScene);
                if (assetPath.EndsWith(".unity"))
                {
                    var mapSceneName = System.IO.Path.GetFileNameWithoutExtension(assetPath);
                    Debug.Log($"MapScene is valid: {mapSceneName}");
                }
                else
                {
                    mapScene = null;
                    Debug.LogError("MapScene is not a valid scene.");
                }
            }
        }
    }
}
