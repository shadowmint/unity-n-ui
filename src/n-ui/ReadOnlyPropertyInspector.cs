#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace N.Package.UI
{
    /// <summary>
    /// Make a property visible in editor, but not modifyable.
    /// Works for: Int, Bool, Float, String, Vector2, Vector3, Vector4,
    ///   Quaternion, Enum
    /// </summary>
    public class ReadOnlyPropertyInspector : PropertyAttribute
    {
        public ReadOnlyPropertyInspector() { }
    }

    /// <summary>
    /// Render the read-only properties.
    /// </summary>
    [CustomPropertyDrawer(typeof(ReadOnlyPropertyInspector))]
    public class ReadOnlyPropertyInspectorDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty prop, GUIContent label)
        {
            string valueStr;

            switch (prop.propertyType)
            {
                case SerializedPropertyType.Integer:
                    valueStr = prop.intValue.ToString();
                    break;
                case SerializedPropertyType.Boolean:
                    valueStr = prop.boolValue.ToString();
                    break;
                case SerializedPropertyType.Float:
                    valueStr = prop.floatValue.ToString("0.00000");
                    break;
                case SerializedPropertyType.String:
                    valueStr = prop.stringValue;
                    break;
                case SerializedPropertyType.Vector2:
                    valueStr = prop.vector2Value.ToString();
                    break;
                case SerializedPropertyType.Vector3:
                    valueStr = prop.vector3Value.ToString();
                    break;
                case SerializedPropertyType.Vector4:
                    valueStr = prop.vector4Value.ToString();
                    break;
                case SerializedPropertyType.Quaternion:
                    valueStr = prop.quaternionValue.ToString();
                    break;
                case SerializedPropertyType.Enum:
                    valueStr = prop.enumNames[prop.enumValueIndex];
                    break;
                default:
                    valueStr = prop.propertyType + ": not supported";
                    break;
            }

            EditorGUI.LabelField(position, label.text, valueStr);
        }
    }
}
#else
 
namespace N.Package.UI
{
    public class ReadOnlyPropertyInspector : System.Attribute { }
}
#endif
