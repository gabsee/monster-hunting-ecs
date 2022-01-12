using UnityEngine;

using Leopotam.Ecs;

/// <summary>
/// ScriptableObject which should be in Resources folder to edit TComponent component.
/// </summary>
public class ConfigHolder<TComponent> : AConfigHolder where TComponent : struct
{
    [SerializeField] private TComponent m_config;

    public override void AddConfigToEntity(in EcsEntity p_entity)
    {
        p_entity.Replace(m_config);
    }
}