#if UNITY_EDITOR

using UnityEngine;

using SimpleECS;

public class EntityDebug : MonoBehaviour
{
    private Entity m_entity;
    public Entity Entity => m_entity;

    public void SetEntity(in Entity p_entity)
    {
        m_entity = p_entity;
    }
}

#endif