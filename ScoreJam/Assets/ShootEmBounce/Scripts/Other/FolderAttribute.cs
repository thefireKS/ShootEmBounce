using UnityEngine;
using UnityEditor;

public class FolderAttribute : PropertyAttribute { }

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(FolderAttribute))]
public class FolderAttributeDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (property.propertyType == SerializedPropertyType.ObjectReference)
        {
            EditorGUI.BeginProperty(position, label, property);

            Object obj = EditorGUI.ObjectField(position, label, property.objectReferenceValue, typeof(Object), false);

            if (obj != null)
            {
                string assetPath = AssetDatabase.GetAssetPath(obj);
                if (!AssetDatabase.IsValidFolder(assetPath))
                {
                    Debug.LogWarning("Выбранный объект не является папкой!");
                    obj = null;
                }
            }

            property.objectReferenceValue = obj;

            EditorGUI.EndProperty();
        }
        else
        {
            EditorGUI.PropertyField(position, property, label);
        }
    }
}
#endif