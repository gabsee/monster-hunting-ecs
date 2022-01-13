using Leopotam.Ecs;

/// <summary>
/// Utility class to provide all gameplay systems that should run in the given order.
/// </summary>
public static class GameSystems
{
    public static EcsSystems AddGameSystems(this EcsSystems p_systems)
    {
        return p_systems
            .Add(new PlayerSpawner())
            .Add(new PlayerController())
            .Add(new MonstersSpawner())
            .Add(new RotateAroundSystem())
            .Add(new ProjectileCreator())
            .Add(new ProjectileMover())
            .Add(new ProjectileHitDetection())
            .Add(new ProjectileLifetimeHandler())
            .Add(new ViewUpdaterSystem<Score>());
    }
}
