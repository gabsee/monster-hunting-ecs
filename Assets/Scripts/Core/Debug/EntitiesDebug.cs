#if UNITY_EDITOR

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using SimpleECS;

public class EntitiesDebug
{
    private readonly World m_world;
    private readonly GameObject m_debugParent;
    private readonly Dictionary<Entity, EntityDebug> m_entityDebugs = new Dictionary<Entity, EntityDebug>();

    public EntitiesDebug(World p_world)
    {
        m_world = p_world;

        m_debugParent = new GameObject("[Entities Debug]");
        m_debugParent.hideFlags = HideFlags.NotEditable;
        GameObject.DontDestroyOnLoad(m_debugParent);

        Update();
    }

    public void Update()
    {
        var entities = m_world.GetEntities();
        foreach (var entity in entities)
        {
            if (m_entityDebugs.ContainsKey(entity))
            {
                continue;
            }

            var debugGameObject = new GameObject("Entity");
            debugGameObject.transform.SetParent(m_debugParent.transform);
            debugGameObject.hideFlags = HideFlags.NotEditable;

            var entityDebug = debugGameObject.AddComponent<EntityDebug>();
            entityDebug.SetEntity(entity);

            m_entityDebugs.Add(entity, entityDebug);
        }

        var destroyedEntities = m_entityDebugs.Keys
            .Where(e => !e.IsValid())
            .ToList();

        foreach (var destroyedEntity in destroyedEntities)
        {
            GameObject.Destroy(m_entityDebugs[destroyedEntity].gameObject);
            m_entityDebugs.Remove(destroyedEntity);
        }

        EntityDebugEditor.RepaintAll();
    }

    public void Destroy()
    {
        m_entityDebugs.Clear();
        GameObject.Destroy(m_debugParent);
    }
}

#endif
