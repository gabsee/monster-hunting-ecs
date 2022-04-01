using UnityEngine;

using SimpleECS;

/// <summary>
/// Creates entities for monsters based on MonsterConfig.
/// Monsters are randomly spawned across the world with random RotateAround component.
/// </summary>
public class MonstersSpawner : BaseSystem
{
    public override void Initialize()
    {
        MonsterConfig monsterConfig = Main.World.GetData<MonsterConfig>();

        for (int i = 0; i < monsterConfig.MonstersCount; i++)
        {
            var position = new Vector3(
                Random.Range(monsterConfig.MonsterSpawnMinPosition.x, monsterConfig.MonsterSpawnMaxPosition.x),
                0f,
                Random.Range(monsterConfig.MonsterSpawnMinPosition.y, monsterConfig.MonsterSpawnMaxPosition.y)
            );

            Entity monsterEntity = Main.World.CreateEntity(
                new Position()
                {
                    Value = position
                },
                new Rotation()
                {
                    Value = Quaternion.identity
                },
                new RotateAround()
                {
                    Point = position + new Vector3(
                        Random.Range(monsterConfig.MonsterMinDistanceToRotationPoint, monsterConfig.MonsterMaxDistanceToRotationPoint),
                        0f,
                        Random.Range(monsterConfig.MonsterMinDistanceToRotationPoint, monsterConfig.MonsterMaxDistanceToRotationPoint)
                    ),
                    DegreesPerSecond = monsterConfig.MonsterSpeedDegreesPerSecond
                },
                new ProjectileTarget(),
                new ViewPrefab()
                {
                    Prefab = monsterConfig.MonsterPrefab
                }
            );
        }
    }
}

