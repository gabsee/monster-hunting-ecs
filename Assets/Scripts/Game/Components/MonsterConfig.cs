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

    [SerializeField] private Vector2 m_monsterSpawnMinPosition;
    public Vector2 MonsterSpawnMinPosition => m_monsterSpawnMinPosition;

    [SerializeField] private Vector2 m_monsterSpawnMaxPosition;
    public Vector2 MonsterSpawnMaxPosition => m_monsterSpawnMaxPosition;

    [SerializeField] private float m_monsterMinDistanceToRotationPoint;
    public float MonsterMinDistanceToRotationPoint => m_monsterMinDistanceToRotationPoint;

    [SerializeField] private float m_monsterMaxDistanceToRotationPoint;
    public float MonsterMaxDistanceToRotationPoint => m_monsterMaxDistanceToRotationPoint;
}