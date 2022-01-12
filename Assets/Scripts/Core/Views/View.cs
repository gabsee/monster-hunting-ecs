using UnityEngine;

using Leopotam.Ecs;

/// <summary>
/// Mandatory element on all view prefabs.
/// Destroys the view gameobject when the entity is not alive anymore.
/// </summary>
public class View : MonoBehaviour
{
    private EcsEntity m_entity;

    public void Link(EcsEntity p_entity)
    {
        m_entity = p_entity;
    }

    private void Update()
    {
        if (!m_entity.IsAlive())
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}