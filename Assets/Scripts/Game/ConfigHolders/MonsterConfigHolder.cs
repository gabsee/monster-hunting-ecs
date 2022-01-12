using UnityEngine;

/// <summary>
/// ScriptableObject which should be in Resources folder to edit MonsterConfig component.
/// </summary>
[CreateAssetMenu(fileName = "MonsterConfigHolder", menuName = "Configs/MonsterConfig")]
public class MonsterConfigHolder : ConfigHolder<MonsterConfig> { }
