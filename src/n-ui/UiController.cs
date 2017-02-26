using UnityEngine;
using UnityEngine.UI;
using N.Package.Core;
using N.Package.UI;
using System.Collections.Generic;

namespace N.Package.UI {

  public abstract class UiController : MonoBehaviour {

    [Tooltip("Does the UI state need to be updated?")]
    public bool dirty = true;

    [Tooltip("Normal UI update poll interval")]
    public float updateInterval = 0.1f;

    // Elapsed time since the last update
    private float elapsed;

    /// Has initialization happened yet?
    private bool initialized = false;

    /// Periodically update the UI
    public void Update() {
      if (!initialized) {
        Init();
      }
      if (dirty) {
        Redraw();
      }
      else {
        elapsed += Time.deltaTime;
        if (elapsed > updateInterval) {
          dirty = true;
        }
      }
      Pick();
    }

    /// Poll for raycast object picking
    protected virtual void Pick() {
    }

    /// Load all the tags we can find.
    /// Call this in Start() on the child class, as unity cannot resolve
    /// Start() methods in parent classes.
    protected void Init() {
      initialized = true;
      var targets = Marker.Find(Tags(), gameObject);
      if (targets) {
        Setup(targets.Unwrap());
        Redraw();
      }
      else {
        Console.Error("Failed to load UI targets");
      }
    }

    /// Redraw the UI
    public void Redraw() {
      dirty = false;
      elapsed = 0f;
      if (Ready()) {
        Sync();
      }
    }

    /// Run periodically and only start this UI once it returns true.
    protected abstract bool Ready();

    /// Return a list of tags to find
    protected abstract string[] Tags();

    /// Handle the collection of UI targets
    protected abstract void Setup(Dictionary<string, GameObject> targets);

    /// Update the UI state based on the state
    protected abstract void Sync();
  }
}
