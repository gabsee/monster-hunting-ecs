using System;

using UnityEngine;

/// <summary>
/// Configuration of the monster entities and their views.
/// </summary>
[Serializable]
public struct MonsterConfig
{
    [SerializeField] private int m_monstersCount;
    public int MonstersCount => m_monstersCount;

    [SerializeField] private GameObject m_monsterPrefab;
    public GameObject MonsterPrefab => m_monsterPrefab;

    [SerializeField] private float m_monsterSpeedDegreesPerSecond;
    public float MonsterSpeedDegreesPerSecond => m_monsterSpeedDegreesPerSecond;
}