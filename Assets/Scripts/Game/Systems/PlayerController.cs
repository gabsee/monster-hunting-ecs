using UnityEngine;
using UnityEngine.InputSystem;

using Leopotam.Ecs;

/// <summary>
/// Moves and rotates player entity based on user inputs and Player component values. 
/// </summary>
public class PlayerController : IEcsInitSystem, IEcsRunSystem
{
    // Auto-injected field
    private EcsFilter<PlayerConfig> m_playerConfigFilter = null;
    private EcsFilter<Player, Position, Rotation> m_playerFilter = null;

    private InputsActions m_inputActions;
    private Vector2 m_moveInput;
    private float m_xRotation;
    private float m_yRotation;

    public void Init()
    {
        m_inputActions = new InputsActions();
        m_inputActions.Enable();

        m_inputActions.PlayerControls.EnableControls.started += _ => Cursor.lockState = CursorLockMode.Locked;
        m_inputActions.PlayerControls.DisableControls.started += _ => Cursor.lockState = CursorLockMode.None;
    }

    public void Run()
    {
        if (Cursor.lockState == CursorLockMode.None ||
            m_playerFilter.IsEmpty())
        {
            return;
        }

        if (m_playerConfigFilter.IsEmpty())
        {
            Debug.LogError("Player config not found");
            return;
        }

        ref PlayerConfig playerConfig = ref m_playerConfigFilter.Get1(0);

        ref Position position = ref m_playerFilter.Get2(0);
        ref Rotation rotation = ref m_playerFilter.Get3(0);

        m_moveInput = m_inputActions.PlayerControls.Move.ReadValue<Vector2>();
        m_xRotation = m_inputActions.PlayerControls.XRotation.ReadValue<float>();
        m_yRotation = m_inputActions.PlayerControls.YRotation.ReadValue<float>();

        Vector3 moveVector = Vector3.zero;
        moveVector += m_moveInput.y * Vector3.forward;
        moveVector += m_moveInput.x * Vector3.right;

        var deltaTime = Time.deltaTime;

        if (moveVector != Vector3.zero)
        {
            moveVector = moveVector.normalized;
            var flatRotationEulers = rotation.Value.eulerAngles;
            flatRotationEulers.x = 0f;
            moveVector = Quaternion.Euler(flatRotationEulers) * moveVector;
            moveVector *= playerConfig.PlayerSpeedMps * deltaTime;

            position.Value += moveVector;
        }

        var yRotation = m_yRotation * playerConfig.PlayerYRotationSpeed * deltaTime;
        rotation.Value = Quaternion.Euler(0f, yRotation, 0f) * rotation.Value;

        var xRotation = m_xRotation * playerConfig.PlayerXRotationSpeed * deltaTime;
        rotation.Value = rotation.Value * Quaternion.Euler(m_xRotation, 0f, 0f);
    }
}
