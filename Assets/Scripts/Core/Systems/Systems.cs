using System.Collections.Generic;

/// <summary>
/// Contains a group of systems
/// </summary>
public class Systems : BaseSystem
{
    private readonly List<BaseSystem> m_systems = new List<BaseSystem>();

    public void Add<TSystem>() where TSystem : BaseSystem, new()
    {
        m_systems.Add(
            new TSystem()
        );
    }

    public override void Initialize()
    {
        foreach (var system in m_systems)
        {
            system.Initialize();
        }
    }

    public override void Execute()
    {
        foreach (var system in m_systems)
        {
            system.Execute();
        }
    }
}
