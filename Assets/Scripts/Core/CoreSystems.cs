/// <summary>
/// Provide all core systems that should run in the given order.
/// </summary>
public class CoreSystems : Systems
{
    public CoreSystems()
    {
        Add<Destroyer>();
        Add<ConfigsLoader>();
        Add<ViewLoader>();
        Add<ViewUpdaterSystem<Position>>();
        Add<ViewUpdaterSystem<Rotation>>();
    }
}
