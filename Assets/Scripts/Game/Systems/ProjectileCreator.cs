using UnityEngine;

using Leopotam.Ecs;

/// <summary>
/// Creates projectile entity based on ProjectilesConfig
/// when shoot input action is triggered.
/// </summary>
public class ProjectileCreator : IEcsInitSystem, IEcsRunSystem
{
    // Auto-injected fields
    private EcsWorld m_world = null;
    private EcsFilter<Player, Position, Rotation> m_playerFilter = null;
    private EcsFilter<ProjectilesConfig> m_projectilesConfigFilter = null;

    private InputsActions m_inputActions;
    private bool m_shoot;

    public void Init()
    {
        m_inputActions = new InputsActions();
        m_inputActions.Enable();

        m_inputActions.Combat.Shoot.started += _ => m_shoot = true;
    }

    public void Run()
    {
        if (!m_shoot)
        {
            return;
        }
        m_shoot = false;

        if (Cursor.lockState == CursorLockMode.None ||
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

        ref Position playerPosition = ref m_playerFilter.Get2(0);
        ref Rotation playerRotation = ref m_playerFilter.Get3(0);

        Vector3 playerForward = playerRotation.Value * Vector3.forward;

        Vector3 projectilePosition = playerPosition.Value + playerForward;
        Quaternion projectileRotation = playerRotation.Value;

        float destroyTime = Time.time + projectilesConfig.ProjectileLifetime;

        EcsEntity projectileEntity = m_world.NewEntity();
        projectileEntity.Replace<Projectile>(new Projectile() { DestroyTime = destroyTime });
        projectileEntity.Replace<Position>(new Position() { Value = projectilePosition });
        projectileEntity.Replace<Rotation>(new Rotation() { Value = projectileRotation });
        projectileEntity.Replace<ViewPrefab>(new ViewPrefab() { Prefab = projectilesConfig.ProjectilePrefab });
    }
}
