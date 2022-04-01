using UnityEngine;

using SimpleECS;

/// <summary>
/// Creates an instance of the prefab view in the scene for entities with ViewPrefab component.
/// </summary>
public class ViewLoader : BaseSystem
{
    private Query m_query = Main.World.CreateQuery()
        .Has<ViewPrefab>()
        .Not<ViewInstance>();

    public override void Execute()
    {
        m_query.Foreach(entity =>
            {
                ref ViewPrefab viewPrefab = ref entity.Get<ViewPrefab>();

                var instance = GameObject.Instantiate(viewPrefab.Prefab);
                entity.Set<ViewInstance>(
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
        );
    }
}
