using UnityEngine;

using SimpleECS;

/// <summary>
/// Move entities with RotateAround component to make them rotate around a 3D point.
/// </summary>
public class RotateAroundSystem : BaseSystem
{
    private Query m_query = Main.World.CreateQuery()
        .Has<Position>()
        .Has<RotateAround>();

    public override void Execute()
    {
        var deltaTime = Time.deltaTime;

        m_query.Foreach(entity =>
            {
                ref Position position = ref entity.Get<Position>();
                ref RotateAround rotateAround = ref entity.Get<RotateAround>();

                Vector3 centerToPos = position.Value - rotateAround.Point;
                float rotationAngle = deltaTime * rotateAround.DegreesPerSecond;
                Quaternion rotation = Quaternion.Euler(0, rotationAngle, 0);
                centerToPos = rotation * centerToPos;

                position.Value = rotateAround.Point + centerToPos;
            }
        );
    }
}
