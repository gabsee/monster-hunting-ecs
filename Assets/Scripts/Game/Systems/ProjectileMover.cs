using UnityEngine;

using Leopotam.Ecs;

/// <summary>
/// Moves projectile entities.
/// </summary>
public class ProjectileMover : IEcsRunSystem
{
    // Auto-injected fields
    private EcsFilter<Projectile, Position, Rotation> m_projectilesFilter = null;
    private EcsFilter<PlayerConfig> m_playerConfigFilter = null;

    public void Run()
    {
        if (m_projectilesFilter.IsEmpty())
        {
            return;
        }

        if (m_playerConfigFilter.IsEmpty())
        {
            Debug.LogError("Player config not found");
            return;
        }

        ref PlayerConfig playerConfig = ref m_playerConfigFilter.Get1(0);

        var deltaTime = Time.deltaTime;

        foreach (var entityIdx in m_projectilesFilter)
        {
            ref Position projectilePosition = ref m_projectilesFilter.Get2(entityIdx);
            ref Rotation projectileRotation = ref m_projectilesFilter.Get3(entityIdx);

            Vector3 forward = projectileRotation.Value * Vector3.forward;

            projectilePosition.Value += forward * playerConfig.ProjectileSpeedMps * deltaTime;
        }
    }
}
