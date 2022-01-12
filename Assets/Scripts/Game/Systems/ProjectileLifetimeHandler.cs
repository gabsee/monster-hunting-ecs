using UnityEngine;

using Leopotam.Ecs;

/// <summary>
/// Destroys a projectile entity when its lifetime is over.
/// </summary>
public class ProjectileLifetimeHandler : IEcsRunSystem
{
    // Auto-injected field
    private EcsFilter<Projectile> m_projectilesFilter = null;

    public void Run()
    {
        if (m_projectilesFilter.IsEmpty())
        {
            return;
        }

        var time = Time.time;

        foreach (var entityIdx in m_projectilesFilter)
        {
            ref Projectile projectile = ref m_projectilesFilter.Get1(entityIdx);

            if (projectile.DestroyTime > time)
            {
                continue;
            }

            ref EcsEntity projectileEntity = ref m_projectilesFilter.GetEntity(entityIdx);
            projectileEntity.Destroy();
        }
    }
}
