using UnityEngine;

using SimpleECS;

/// <summary>
/// Detect if a projectile is near a target, destroys the target and the projectile if it happens.
/// </summary>
public class ProjectileHitDetection : BaseSystem
{
    private Query m_projectilesQuery = Main.World.CreateQuery()
        .Has<Projectile>()
        .Has<Position>();

    private Query m_targetsQuery = Main.World.CreateQuery()
        .Has<ProjectileTarget>()
        .Has<Position>();

    public override void Execute()
    {
        ProjectilesConfig projectilesConfig = Main.World.GetData<ProjectilesConfig>();

        m_projectilesQuery.Foreach(projectileEntity =>
            {
                Position projectilePosition = projectileEntity.Get<Position>();

                m_targetsQuery.Foreach(targetEntity =>
                    {
                        Position targetPosition = targetEntity.Get<Position>();

                        float distance = Vector3.Distance(projectilePosition.Value, targetPosition.Value);

                        if (distance > projectilesConfig.ProjectileHitDistance)
                        {
                            return;
                        }

                        projectileEntity.Set<Destroy>(new Destroy());
                        targetEntity.Set<Destroy>(new Destroy());
                    }
                );
            }
        );
    }
}
