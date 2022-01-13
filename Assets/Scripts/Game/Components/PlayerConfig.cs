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
}
