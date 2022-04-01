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
        m_systemsUpdaterGameObject.hideFlags = HideFlags.NotEditable;
        GameObject.DontDestroyOnLoad(m_systemsUpdaterGameObject);
        var systemsUpdater = m_systemsUpdaterGameObject.AddComponent<SystemsUpdater>();
        systemsUpdater.OnUpdate += Run;
    }

    private static void Run()
    {
        m_systems.Execute();
    }

    private static void Stop()
    {
        GameObject.Destroy(m_systemsUpdaterGameObject);
        m_systemsUpdaterGameObject = null;

        m_systems = null;

        World.Destroy();
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
