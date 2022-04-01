using UnityEngine;

using SimpleECS;

/// <summary>
/// Creates projectile entity based on ProjectilesConfig
/// when shoot input action is triggered.
/// </summary>
public class ProjectileCreator : BaseSystem
{
    private Query m_query = Main.World.CreateQuery()
        .Has<Player>()
        .Has<Position>()
        .Has<Rotation>();

    private InputsActions m_inputActions;
    private bool m_shoot;

    public override void Initialize()
    {
        m_inputActions = new InputsActions();
        m_inputActions.Enable();

        m_inputActions.Combat.Shoot.started += _ => m_shoot = true;
    }

    public override void Execute()
    {
        if (!m_shoot)
        {
            return;
        }
        m_shoot = false;

        if (Cursor.lockState == CursorLockMode.None)
        {
            return;
        }

        ProjectilesConfig projectilesConfig = Main.World.GetData<ProjectilesConfig>();

        m_query.Foreach(entity =>
            {
                ref Position playerPosition = ref entity.Get<Position>();
                ref Rotation playerRotation = ref entity.Get<Rotation>();

                Vector3 playerForward = playerRotation.Value * Vector3.forward;

                Vector3 projectilePosition = playerPosition.Value + playerForward;
                Quaternion projectileRotation = playerRotation.Value;

                float destroyTime = Time.time + projectilesConfig.ProjectileLifetime;

                Entity projectileEntity = Main.World.CreateEntity(
                    new Projectile() { DestroyTime = destroyTime },
                    new Position() { Value = projectilePosition },
                    new Rotation() { Value = projectileRotation },
                    new ViewPrefab() { Prefab = projectilesConfig.ProjectilePrefab }
                );
            }
        );
    }
}
