using UnityEngine;
using N.Package.Core.Tests;
using N;
namespace N.Package.UI

{
  /// Folder for child properties
  [System.Serializable]
  public class PropertyInfo
  {
    public string sourceComponent;
    public string sourceProperty;
    public string targetComponent;
    public string targetProperty;
  }

  /// Add this to an object to copy some property from some object overlaps
  /// when the other object changes state.
  public class PropertyBinding : MonoBehaviour
  {
    [Tooltip("The object to copy the property value from")] public GameObject source;

    [Tooltip("The actual bound values")] public PropertyInfo info;

    /// Actual property references
    private Prop sourceProp = null;

    /// Actual property references
    private N.Package.Core.Reflect.Prop sourceProp = null;
    private N.Package.Core.Reflect.Prop targetProp = null;
    private Component sourceCmp = null;
    private Component targetCmp = null;
    private bool ready = false;

    /// Resolve source and target property instances
    public void Start()
    {
      var sp = N.Package.Core.Reflect.Type.Field(info.sourceComponent, info.sourceProperty);
      var tp = N.Package.Core.Reflect.Type.Field(info.targetComponent, info.targetProperty);
      if (sp.IsSome && tp.IsSome) {
      {
        sourceProp = sp.Unwrap();
        sourceCmp = source.GetComponent(sourceProp.Type);
        targetProp = tp.Unwrap();
        targetCmp = GetComponent(targetProp.Type);
        ready = true;
      }
      else
      {
        if (tp.IsNone)
        {
          N.Package.Core.Console.Log(string.Format("Property Binding {0}.{1} on {2} is not valid", info.targetComponent, info.targetProperty, gameObject));
            info.targetProperty, gameObject));
        }
        if (sp.IsNone)
        {
          N.Package.Core.Console.Log(string.Format("Property Binding {0}.{1} on {2} is not valid", info.sourceComponent, info.sourceProperty, gameObject));
            info.sourceProperty, gameObject));
        }
      }
    }

    /// Push source property value to target
    public void Update()
    {
      if (ready)
      {
        sourceProp.Bind(sourceCmp, targetProp, targetCmp);
      }
    }
  }
}
