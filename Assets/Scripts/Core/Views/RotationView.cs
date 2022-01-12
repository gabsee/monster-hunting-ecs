using UnityEngine;

/// <summary>
/// View of Rotation component. 
/// Sets view gameobject transform rotation with value of Rotation component.
/// </summary>
public class RotationView : MonoBehaviour, IView<Rotation>
{
    public void ComponentUpdate(ref Rotation p_rotation)
    {
        transform.rotation = p_rotation.Value;
    }
}
