
using UnityEngine;

/// <summary>
/// Foreach AConfigHolder in Resources, creates an entity with holded config as component
/// </summary>
public class ConfigsLoader : BaseSystem
{
    public override void Initialize()
    {
        var configHolders = Resources.LoadAll<AConfigHolder>(string.Empty);

        foreach (var configHolder in configHolders)
        {
            configHolder.InjectConfig();
        }
    }
}
