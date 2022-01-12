using System;

using UnityEngine;

/// <summary>
/// Configuration of the player entity and its view.
/// </summary>
[Serializable]
public struct PlayerConfig
{
    [SerializeField] private GameObject m_playerPrefab;
    public GameObject PlayerPrefab => m_playerPrefab;

    [SerializeField] private float m_playerSpeedMps;
    public float PlayerSpeedMps => m_playerSpeedMps;

    [SerializeField] private float m_playerYRotationSpeed;
    public float PlayerYRotationSpeed => m_playerYRotationSpeed;

    [SerializeField] private float m_playerXRotationSpeed;
    public float PlayerXRotationSpeed => m_playerXRotationSpeed;

    [SerializeField] private GameObject m_projectilePrefab;
    public GameObject ProjectilePrefab => m_projectilePrefab;

    [SerializeField] private float m_projectileSpeedMps;
    public float ProjectileSpeedMps => m_projectileSpeedMps;

    [SerializeField] private float m_projectileHitDistance;
    public float ProjectileHitDistance => m_projectileHitDistance;

    [SerializeField] private float m_projectileLifetime;
    public float ProjectileLifetime => m_projectileLifetime;
}
