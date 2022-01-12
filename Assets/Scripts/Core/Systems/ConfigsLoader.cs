using UnityEngine;

using Leopotam.Ecs;

/// <summary>
/// Foreach AConfigHolder in Resources, creates an entity with holded config as component
/// </summary>
public class ConfigsLoader : IEcsInitSystem
{
    // Auto-injected field
    private EcsWorld m_world = null;

    public void Init()
    {
        var configHolders = Resources.LoadAll<AConfigHolder>(string.Empty);

        foreach (var configHolder in configHolders)
        {
            EcsEntity configEntity = m_world.NewEntity();
            configHolder.AddConfigToEntity(configEntity);
        }
    }
}