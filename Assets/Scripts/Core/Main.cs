using System;

using UnityEngine;

using SimpleECS;

/// <summary>
/// Entry point of the game.
/// Creates ECS world and systems and update them every tick.
/// </summary>
public static class Main
{
    public static World World { get; private set; }

    private static Systems m_systems;
    private static GameObject m_systemsUpdaterGameObject;

#if UNITY_EDITOR
    private static EntitiesDebug m_entitiesDebug;
#endif

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Start()
    {
        Application.targetFrameRate = 60;

        CreateWorld();
        CreateSystems();
        CreateSystemsRunner();
    }

    private static void CreateWorld()
    {
        World = World.Create();

#if UNITY_EDITOR
        m_entitiesDebug = new EntitiesDebug(World);
#endif
    }

    private static void CreateSystems()
    {
        m_systems = new Systems();
        m_systems.Add<CoreSystems>();
        m_systems.Add<GameSystems>();
        m_systems.Initialize();
    }

    private static void CreateSystemsRunner()
    {
        m_systemsUpdaterGameObject = new GameObject("[SystemsUpdater]");
        m_systemsUpdaterGameObject.hideFlags = HideFlags.HideAndDontSave;
        GameObject.DontDestroyOnLoad(m_systemsUpdaterGameObject);
        var systemsUpdater = m_systemsUpdaterGameObject.AddComponent<SystemsUpdater>();
        systemsUpdater.OnUpdate += Run;
    }

    private static void Run()
    {
        m_systems.Execute();

#if UNITY_EDITOR
        m_entitiesDebug.Update();
#endif
    }

    private static void Stop()
    {
        GameObject.Destroy(m_systemsUpdaterGameObject);
        m_systemsUpdaterGameObject = null;

        m_systems = null;

        World.Destroy();

#if UNITY_EDITOR
        m_entitiesDebug.Destroy();
        m_entitiesDebug = null;
#endif
    }

    private class SystemsUpdater : MonoBehaviour
    {
        public event Action OnUpdate;

        private void Update()
        {
            OnUpdate?.Invoke();
        }
    }
}
