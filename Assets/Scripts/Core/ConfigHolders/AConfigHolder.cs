using UnityEngine;

/// <summary>
/// ScriptableObject which should be in Resources folder to edit a config component.
/// </summary>
public abstract class AConfigHolder : ScriptableObject
{
    public abstract void InjectConfig();
}
