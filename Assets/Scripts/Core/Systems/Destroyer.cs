using SimpleECS;

/// <summary>
/// Destroy entities with Destroy component
/// </summary>
public class Destroyer : BaseSystem
{
    private Query m_query = Main.World.CreateQuery()
        .Has<Destroy>();

    public override void Execute()
    {
        m_query.Foreach(entity =>
            {
                entity.Destroy();
            }
        );
    }
}
