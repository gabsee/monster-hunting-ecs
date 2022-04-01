/// <summary>
/// Provide all gameplay systems that should run in the given order.
/// </summary>
public class GameSystems : Systems
{
    public GameSystems()
    {
        Add<PlayerSpawner>();
        Add<PlayerController>();
        Add<MonstersSpawner>();
        Add<RotateAroundSystem>();
        Add<ProjectileCreator>();
        Add<ProjectileMover>();
        Add<ProjectileHitDetection>();
        Add<PlayerScoreComputer>();
        Add<ProjectileLifetimeHandler>();
        Add<ViewUpdaterSystem<Score>>();
    }
}