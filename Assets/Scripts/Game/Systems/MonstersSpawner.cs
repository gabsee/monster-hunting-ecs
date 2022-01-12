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
                    Random.Range(0f, 100f),
                    0f,
                    Random.Range(0f, 100f)
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
                    Random.Range(-5f, 5f),
                    0f,
                    Random.Range(-5f, 5f)
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

