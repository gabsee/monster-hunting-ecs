using UnityEngine;

/// <summary>
/// ScriptableObject which should be in Resources folder to edit TComponent component.
/// </summary>
public class ConfigHolder<TComponent> : AConfigHolder where TComponent : struct
{
    [SerializeField] private TComponent m_config;

    public override void InjectConfig()
    {
        Main.World.SetData<TComponent>(m_config);
    }
}