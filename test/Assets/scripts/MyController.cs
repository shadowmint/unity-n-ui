using System;
using System.Collections.Generic;
using UnityEngine;
using N.Package.UI;

public class MyController : UiController
{
    public MyState state;

    private MyStateObjects objects = null;

    /// If waiting for some init, do it here.
    protected override bool Ready()
    {
        return true;
    }

    /// Return the list of tags
    protected override string[] Tags()
    {
        return new string[] {
            "Name",
            "Value",
        };
    }

    /// Handle the collection of UI targets
    protected override void Setup(Dictionary<string, GameObject> targets)
    {
        objects = new MyStateObjects();
        objects.name = targets["Name"];
        objects.value = targets["Value"];
    }

    /// Sync state to UI
    protected override void Sync()
    {
        if (objects != null) {
            objects.name.SetText(state.name);
            objects.value.SetSlider(state.value);
        }
    }
}

[Serializable]
public class MyState
{
    public string name;
    public float value;
}

public class MyStateObjects
{
    public GameObject name;
    public GameObject value;
}
