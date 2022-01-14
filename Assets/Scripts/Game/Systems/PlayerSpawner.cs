using UnityEngine;

using Leopotam.Ecs;

/// <summary>
/// Creates player entity based on PlayerConfig.
/// </summary>
public class PlayerSpawner : IEcsInitSystem
{
    // Auto-injected fields
    private EcsWorld m_world = null;
    private EcsFilter<PlayerConfig> m_playerConfigFilter = null;

    public void Init()
    {
        if (m_playerConfigFilter.IsEmpty())
        {
            Debug.LogError("Player config not found");
            return;
        }

        ref PlayerConfig playerConfig = ref m_playerConfigFilter.Get1(0);

        EcsEntity playerEntity = m_world.NewEntity();

        playerEntity.Replace<Player>(new Player());

        var position = new Position()
        {
            Value = new Vector3(
                Random.Range(playerConfig.PlayerSpawnMinPosition.x, playerConfig.PlayerSpawnMaxPosition.x),
                playerConfig.PlayerHeight,
                Random.Range(playerConfig.PlayerSpawnMinPosition.y, playerConfig.PlayerSpawnMaxPosition.y)
            )
        };
        playerEntity.Replace<Position>(position);

        var rotation = new Rotation()
        {
            Value = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f)
        };
        playerEntity.Replace<Rotation>(rotation);

        playerEntity.Replace<ViewPrefab>(new ViewPrefab()
        {
            Prefab = playerConfig.PlayerPrefab
        });
    }
}

