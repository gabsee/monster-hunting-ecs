using UnityEngine;

using SimpleECS;

/// <summary>
/// Creates player entity based on PlayerConfig.
/// </summary>
public class PlayerSpawner : BaseSystem
{
    public override void Initialize()
    {
        PlayerConfig playerConfig = Main.World.GetData<PlayerConfig>();

        Entity playerEntity = Main.World.CreateEntity(
            new Player(),
            new Position()
            {
                Value = new Vector3(
                    Random.Range(
                        playerConfig.PlayerSpawnMinPosition.x,
                        playerConfig.PlayerSpawnMaxPosition.x
                    ),
                    playerConfig.PlayerHeight,
                    Random.Range(
                        playerConfig.PlayerSpawnMinPosition.y,
                        playerConfig.PlayerSpawnMaxPosition.y
                    )
                )
            },
            new Rotation()
            {
                Value = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f)
            },
            new ViewPrefab()
            {
                Prefab = playerConfig.PlayerPrefab
            }
        );
    }
}

