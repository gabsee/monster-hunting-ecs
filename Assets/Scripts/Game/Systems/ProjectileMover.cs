using UnityEngine;

using SimpleECS;

/// <summary>
/// Moves projectile entities.
/// </summary>
public class ProjectileMover : BaseSystem
{
    private Query m_query = Main.World.CreateQuery()
        .Has<Projectile>()
        .Has<Position>()
        .Has<Rotation>();

    public override void Execute()
    {
        ProjectilesConfig projectilesConfig = Main.World.GetData<ProjectilesConfig>();

        var deltaTime = Time.deltaTime;

        m_query.Foreach(entity =>
            {
                ref Position projectilePosition = ref entity.Get<Position>();
                ref Rotation projectileRotation = ref entity.Get<Rotation>();

                Vector3 forward = projectileRotation.Value * Vector3.forward;

                projectilePosition.Value += forward * projectilesConfig.ProjectileSpeedMps * deltaTime;
            }
        );
    }
}
