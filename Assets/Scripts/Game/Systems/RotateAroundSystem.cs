using UnityEngine;

using Leopotam.Ecs;

/// <summary>
/// Move entities with RotateAround component to make them rotate around a 3D point.
/// </summary>
public class RotateAroundSystem : IEcsRunSystem
{
    // Auto-injected fields
    private EcsWorld m_world = null;
    private EcsFilter<Position, RotateAround> m_filter = null;

    public void Run()
    {
        if (m_filter.IsEmpty())
        {
            return;
        }

        var deltaTime = Time.deltaTime;

        foreach (var entityIdx in m_filter)
        {
            ref Position position = ref m_filter.Get1(entityIdx);
            ref RotateAround rotateAround = ref m_filter.Get2(entityIdx);

            Vector3 centerToPos = position.Value - rotateAround.Point;
            float rotationAngle = deltaTime * rotateAround.DegreesPerSecond;
            Quaternion rotation = Quaternion.Euler(0, rotationAngle, 0);
            centerToPos = rotation * centerToPos;

            position.Value = rotateAround.Point + centerToPos;
        }
    }
}
