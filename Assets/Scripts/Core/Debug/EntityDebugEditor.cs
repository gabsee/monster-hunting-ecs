#if UNITY_EDITOR

using System.Collections.Generic;

using UnityEditor;

[CustomEditor(typeof(EntityDebug))]
public class EntityDebugEditor : Editor
{
    private static HashSet<EntityDebugEditor> m_editors = new HashSet<EntityDebugEditor>();

    void OnEnable()
    {
        m_editors.Add(this);
    }

    void OnDisable()
    {
        m_editors.Remove(this);
    }

    public static void RepaintAll()
    {
        foreach (var editor in m_editors)
        {
            editor.Repaint();
        }
    }

    public override void OnInspectorGUI()
    {
        var entity = ((EntityDebug)target).Entity;

        if (!entity.IsValid())
        {
            return;
        }

        var components = entity.GetAllComponents();
        foreach (var component in components)
        {
            if (component == null)
            {
                continue;
            }

            var componentType = component.GetType();
            EditorGUILayout.LabelField(componentType.Name);

            var fields = componentType.GetFields();
            if (fields.Length == 0)
            {
                continue;
            }

            EditorGUI.indentLevel++;
            foreach (var field in fields)
            {
                EditorGUILayout.TextField(field.Name, field.GetValue(component).ToString());
            }
            EditorGUI.indentLevel--;
        }
    }
}

#endif
