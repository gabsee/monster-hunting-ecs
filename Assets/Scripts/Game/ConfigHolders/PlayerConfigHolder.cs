using UnityEngine;

/// <summary>
/// ScriptableObject which should be in Resources folder to edit PlayerConfig component.
/// </summary>
[CreateAssetMenu(fileName = "PlayerConfigHolder", menuName = "Configs/PlayerConfig")]
public class PlayerConfigHolder : ConfigHolder<PlayerConfig> { }