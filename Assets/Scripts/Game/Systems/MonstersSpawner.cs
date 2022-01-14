using UnityEngine;

using Leopotam.Ecs;

/// <summary>
/// Creates entities for monsters based on MonsterConfig.
/// Monsters are randomly spawned across the world with random RotateAround component.
/// </summary>
public class MonstersSpawner : IEcsInitSystem
{
    // Auto-injected fields
    private EcsWorld m_world = null;
    private EcsFilter<MonsterConfig> m_monsterConfigFilter = null;

    public void Init()
    {
        if (m_monsterConfigFilter.IsEmpty())
        {
            Debug.LogError("Monster config not found");
            return;
        }

        ref MonsterConfig monsterConfig = ref m_monsterConfigFilter.Get1(0);

        for (int i = 0; i < monsterConfig.MonstersCount; i++)
        {
            EcsEntity monsterEntity = m_world.NewEntity();

            var position = new Position()
            {
                Value = new Vector3(
                    Random.Range(monsterConfig.MonsterSpawnMinPosition.x, monsterConfig.MonsterSpawnMaxPosition.x),
                    0f,
                    Random.Range(monsterConfig.MonsterSpawnMinPosition.y, monsterConfig.MonsterSpawnMaxPosition.y)
                )
            };
            monsterEntity.Replace<Position>(position);

            var rotation = new Rotation()
            {
                Value = Quaternion.identity
            };
            monsterEntity.Replace<Rotation>(rotation);

            var rotateAround = new RotateAround()
            {
                Point = position.Value + new Vector3(
                    Random.Range(monsterConfig.MonsterMinDistanceToRotationPoint, monsterConfig.MonsterMaxDistanceToRotationPoint),
                    0f,
                    Random.Range(monsterConfig.MonsterMinDistanceToRotationPoint, monsterConfig.MonsterMaxDistanceToRotationPoint)
                ),
                DegreesPerSecond = monsterConfig.MonsterSpeedDegreesPerSecond
            };
            monsterEntity.Replace<RotateAround>(rotateAround);

            monsterEntity.Replace<ProjectileTarget>(new ProjectileTarget());

            monsterEntity.Replace<ViewPrefab>(new ViewPrefab()
            {
                Prefab = monsterConfig.MonsterPrefab
            });
        }
    }
}

