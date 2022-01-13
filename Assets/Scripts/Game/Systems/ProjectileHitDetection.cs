using UnityEngine;

using Leopotam.Ecs;

public class ProjectileHitDetection : IEcsRunSystem
{
    // Auto-injected fields
    private EcsFilter<Projectile, Position> m_projectilesFilter = null;
    private EcsFilter<ProjectileTarget, Position> m_targetsFilter = null;
    private EcsFilter<Player> m_playerFilter = null;
    private EcsFilter<ProjectilesConfig> m_projectilesConfigFilter = null;

    public void Run()
    {
        if (m_projectilesFilter.IsEmpty() ||
            m_targetsFilter.IsEmpty() ||
            m_playerFilter.IsEmpty())
        {
            return;
        }

        if (m_projectilesConfigFilter.IsEmpty())
        {
            Debug.LogError("Projectiles config not found");
            return;
        }

        ref ProjectilesConfig projectilesConfig = ref m_projectilesConfigFilter.Get1(0);
        ref EcsEntity playerEntity = ref m_playerFilter.GetEntity(0);

        foreach (var projectileIdx in m_projectilesFilter)
        {
            ref Position projectilePosition = ref m_projectilesFilter.Get2(projectileIdx);

            foreach (var targetIdx in m_targetsFilter)
            {
                ref Position targetPosition = ref m_targetsFilter.Get2(targetIdx);

                float distance = Vector3.Distance(projectilePosition.Value, targetPosition.Value);

                if (distance > projectilesConfig.ProjectileHitDistance)
                {
                    continue;
                }

                m_projectilesFilter.GetEntity(projectileIdx).Destroy();
                m_targetsFilter.GetEntity(targetIdx).Destroy();

                int score = playerEntity.Has<Score>() ?
                    playerEntity.Get<Score>().Value + 1 :
                    1;

                playerEntity.Replace<Score>(new Score() { Value = score });
            }
        }
    }
}