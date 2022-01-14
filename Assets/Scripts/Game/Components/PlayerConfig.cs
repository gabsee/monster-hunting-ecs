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

    [SerializeField] private Vector2 m_playerSpawnMinPosition;
    public Vector2 PlayerSpawnMinPosition => m_playerSpawnMinPosition;

    [SerializeField] private Vector2 m_playerSpawnMaxPosition;
    public Vector2 PlayerSpawnMaxPosition => m_playerSpawnMaxPosition;

    [SerializeField] private float m_playerHeight;
    public float PlayerHeight => m_playerHeight;
}
