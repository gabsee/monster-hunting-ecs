using UnityEngine;

using SimpleECS;

/// <summary>
/// Mandatory element on all view prefabs.
/// Destroys the view gameobject when the entity is not alive anymore.
/// </summary>
public class View : MonoBehaviour
{
    private Entity m_entity;

    public void Link(in Entity p_entity)
    {
        m_entity = p_entity;
    }

    private void Update()
    {
        if (!m_entity.IsValid())
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}