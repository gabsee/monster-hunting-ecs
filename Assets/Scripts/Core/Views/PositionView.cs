using UnityEngine;

/// <summary>
/// View of Position component. 
/// Sets view gameobject transform position with value of Position component.
/// </summary>
public class PositionView : MonoBehaviour, IView<Position>
{
    public void ComponentUpdate(ref Position p_position)
    {
        transform.position = p_position.Value;
    }
}
