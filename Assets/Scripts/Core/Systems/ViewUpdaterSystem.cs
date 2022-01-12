using Leopotam.Ecs;

/// <summary>
/// Updates IView components on view gameobjects with values of associated components.
/// </summary>
public class ViewUpdaterSystem<TComponent> : IEcsRunSystem where TComponent : struct
{
    // Auto-injected field
    private EcsFilter<ViewInstance, TComponent> m_filter = null;

    public void Run()
    {
        if (m_filter.IsEmpty())
        {
            return;
        }

        foreach (var entityIdx in m_filter)
        {
            ref ViewInstance viewInstance = ref m_filter.Get1(entityIdx);

            if (!viewInstance.Instance.TryGetComponent(out IView<TComponent> componentView))
            {
                continue;
            }

            ref TComponent component = ref m_filter.Get2(entityIdx);
            componentView.ComponentUpdate(ref component);
        }
    }
}
