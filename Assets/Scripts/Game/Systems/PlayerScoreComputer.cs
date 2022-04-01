
using SimpleECS;
/// <summary>
/// Increases player score for each destroyed target
/// </summary>
public class PlayerScoreComputer : BaseSystem
{
    private Query m_destroyedTargetsQuery = Main.World.CreateQuery()
        .Has<ProjectileTarget>()
        .Has<Destroy>();

    private Query m_playerQuery = Main.World.CreateQuery()
        .Has<Player>();

    public override void Execute()
    {
        var destroyedTargetsCount = m_destroyedTargetsQuery.EntityCount;

        m_playerQuery.Foreach(playerEntity =>
            {
                int score = playerEntity.Has<Score>() ?
                    playerEntity.Get<Score>().Value + destroyedTargetsCount :
                    destroyedTargetsCount;

                playerEntity.Set<Score>(new Score() { Value = score });
            }
        );
    }
}