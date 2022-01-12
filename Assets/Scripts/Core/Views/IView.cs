/// <summary>
/// Interface that MonoBehaviours should implementent on view prefabs/gameObjects to react to component changes.
/// </summary>
public interface IView<TComponent> where TComponent : struct
{
    void ComponentUpdate(ref TComponent p_component);
}
