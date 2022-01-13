using UnityEngine;

/// <summary>
/// ScriptableObject which should be in Resources folder to edit ProjectilesConfig component.
/// </summary>
[CreateAssetMenu(fileName = "ProjectilesConfigHolder", menuName = "Configs/ProjectilesConfig")]
public class ProjectilesConfigHolder : ConfigHolder<ProjectilesConfig> { }