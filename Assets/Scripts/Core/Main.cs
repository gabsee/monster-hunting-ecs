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
    private static GameObject m_mainUpdaterGameObject;
    private static EcsSystems m_systems;
    private static EcsWorld m_world;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Start()
    {
        Application.targetFrameRate = 60;

        m_world = new EcsWorld();

#if UNITY_EDITOR
        EcsWorldObserver.Create(m_world);
#endif

        m_systems = new EcsSystems(m_world);
        m_systems.Add(new ConfigsLoader());
        m_systems.Add(new ViewLoader());
        m_systems.AddGameSystems();
        m_systems.Add(new ViewUpdaterSystem<Position>());
        m_systems.Add(new ViewUpdaterSystem<Rotation>());
        m_systems.Init();

#if UNITY_EDITOR
        EcsSystemsObserver.Create(m_systems);
#endif   

        m_mainUpdaterGameObject = new GameObject("[MainUpdater]");
        var mainUpdater = m_mainUpdaterGameObject.AddComponent<MainUpdater>();
        mainUpdater.OnUpdate += Run;
        GameObject.DontDestroyOnLoad(m_mainUpdaterGameObject);
    }

    private static void Run()
    {
        m_systems.Run();
    }

    private static void Stop()
    {
        GameObject.Destroy(m_mainUpdaterGameObject);
        m_mainUpdaterGameObject = null;

        m_systems.Destroy();
        m_systems = null;

        m_world.Destroy();
        m_world = null;
    }

    public class MainUpdater : MonoBehaviour
    {
        public event Action OnUpdate;

        private void Update()
        {
            OnUpdate?.Invoke();
        }
    }
}
