using UnityEditor;
using UnityEngine;

namespace ShootEmBounce.Scripts.Data
{
    [CustomEditor(typeof(Item))]
    [CanEditMultipleObjects]
    public class ItemEditor : Editor
    {
        private SerializedProperty previewImage;

        private void OnEnable()
        {
            previewImage = serializedObject.FindProperty("previewImage");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(previewImage, new GUIContent("Preview Image"));

            serializedObject.ApplyModifiedProperties();
        }
    }
}
