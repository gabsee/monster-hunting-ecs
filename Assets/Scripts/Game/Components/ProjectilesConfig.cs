using System;

using UnityEngine;

/// <summary>
/// Configuration for projectiles.
/// </summary>
[Serializable]
public struct ProjectilesConfig
{
    [SerializeField] private GameObject m_projectilePrefab;
    public GameObject ProjectilePrefab => m_projectilePrefab;

    [SerializeField] private float m_projectileSpeedMps;
    public float ProjectileSpeedMps => m_projectileSpeedMps;

    [SerializeField] private float m_projectileHitDistance;
    public float ProjectileHitDistance => m_projectileHitDistance;

    [SerializeField] private float m_projectileLifetime;
    public float ProjectileLifetime => m_projectileLifetime;
}