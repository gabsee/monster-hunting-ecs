using UnityEngine;

using SimpleECS;

/// <summary>
/// Destroys a projectile entity when its lifetime is over.
/// </summary>
public class ProjectileLifetimeHandler : BaseSystem
{
    private Query m_query = Main.World.CreateQuery()
        .Has<Projectile>();

    public override void Execute()
    {
        var time = Time.time;

        m_query.Foreach(entity =>
            {
                ref Projectile projectile = ref entity.Get<Projectile>();

                if (projectile.DestroyTime > time)
                {
                    return;
                }

                entity.Set<Destroy>(new Destroy());
            }
        );
    }
}
