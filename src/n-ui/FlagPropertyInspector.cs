#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace N.Package.UI
{
    /// <summary>
    /// Use Enums as muli-select options, rather than single-select options
    /// </summary>
    public class FlagInspector : PropertyAttribute
    {
        public FlagInspector() { }
    }

    /// <summary>
    /// Render the flags properly.
    /// </summary>
    [CustomPropertyDrawer(typeof(FlagInspector))]
    public class FlagInspectorDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect _position, SerializedProperty _property, GUIContent _label)
        {
            _property.intValue = EditorGUI.MaskField(_position, _label, _property.intValue, _property.enumNames);
        }
    }
}

#else
 
namespace N.Package.UI
{
    public class FlagInspector : System.Attribute { }
}
#endif
