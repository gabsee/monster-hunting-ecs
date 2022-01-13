using Leopotam.Ecs;

/// <summary>
/// Utility class to provide all core systems that should run in the given order.
/// </summary>
public static class CoreSystems
{
    public static EcsSystems AddCoreSystems(this EcsSystems p_systems)
    {
        return p_systems
            .Add(new ConfigsLoader())
            .Add(new ViewLoader())
            .Add(new ViewUpdaterSystem<Position>())
            .Add(new ViewUpdaterSystem<Rotation>());
    }
}
