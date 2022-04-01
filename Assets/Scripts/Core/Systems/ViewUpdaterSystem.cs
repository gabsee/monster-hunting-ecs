using SimpleECS;

/// <summary>
/// Updates IView components on view gameobjects with values of associated components.
/// </summary>
public class ViewUpdaterSystem<TComponent> : BaseSystem where TComponent : struct
{
    private Query m_query = Main.World.CreateQuery()
        .Has<ViewInstance>()
        .Has<TComponent>();

    public override void Execute()
    {
        m_query.Foreach(entity =>
            {
                ref ViewInstance viewInstance = ref entity.Get<ViewInstance>();

                if (!viewInstance.Instance.TryGetComponent(out IView<TComponent> componentView))
                {
                    return;
                }

                ref TComponent component = ref entity.Get<TComponent>();
                componentView.ComponentUpdate(ref component);
            }
        );
    }
}
