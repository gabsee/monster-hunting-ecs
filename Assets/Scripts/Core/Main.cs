using System;

using UnityEngine;

using Leopotam.Ecs;

#if UNITY_EDITOR
using Leopotam.Ecs.UnityIntegration;
#endif   

/// <summary>
/// Entry point of the game.
/// Creates ECS world and systems and update them every tick.
/// </summary>
public static class Main
{
    private static EcsWorld m_world;
    private static EcsSystems m_systems;
    private static GameObject m_systemsUpdaterGameObject;

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
        m_world = new EcsWorld();

#if UNITY_EDITOR
        EcsWorldObserver.Create(m_world);
#endif
    }

    private static void CreateSystems()
    {
        m_systems = new EcsSystems(m_world);
        m_systems.AddCoreSystems();
        m_systems.AddGameSystems();
        m_systems.Init();

#if UNITY_EDITOR
        EcsSystemsObserver.Create(m_systems);
#endif   
    }

    private static void CreateSystemsRunner()
    {
        m_systemsUpdaterGameObject = new GameObject("[SystemsUpdater]");
        m_systemsUpdaterGameObject.hideFlags = HideFlags.NotEditable;
        GameObject.DontDestroyOnLoad(m_systemsUpdaterGameObject);
        var systemsUpdater = m_systemsUpdaterGameObject.AddComponent<SystemsUpdater>();
        systemsUpdater.OnUpdate += Run;
    }

    private static void Run()
    {
        m_systems.Run();
    }

    private static void Stop()
    {
        GameObject.Destroy(m_systemsUpdaterGameObject);
        m_systemsUpdaterGameObject = null;

        m_systems.Destroy();
        m_systems = null;

        m_world.Destroy();
        m_world = null;
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
