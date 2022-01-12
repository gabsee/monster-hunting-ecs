using UnityEngine;

using Leopotam.Ecs;

/// <summary>
/// Creates an instance of the prefab view in the scene for entities with ViewPrefab component.
/// </summary>
public class ViewLoader : IEcsRunSystem
{
    // Auto-injected field
    private EcsFilter<ViewPrefab>.Exclude<ViewInstance> m_filter = null;

    public void Run()
    {
        if (m_filter.IsEmpty())
        {
            return;
        }

        foreach (var entityIdx in m_filter)
        {
            ref ViewPrefab viewPrefab = ref m_filter.Get1(entityIdx);
            ref EcsEntity entity = ref m_filter.GetEntity(entityIdx);

            var instance = GameObject.Instantiate(viewPrefab.Prefab);
            entity.Replace<ViewInstance>(
                new ViewInstance()
                {
                    Instance = instance
                }
            );

            if (instance.TryGetComponent(out View view))
            {
                view.Link(entity);
            }
            else
            {
                Debug.LogError($"Prefab {viewPrefab.Prefab.name} does not have View monobehaviour attached.");
            }
        }
    }
}
