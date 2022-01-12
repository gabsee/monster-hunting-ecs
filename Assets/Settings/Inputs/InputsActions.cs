// GENERATED AUTOMATICALLY FROM 'Assets/Settings/Inputs/InputsActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputsActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputsActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputsActions"",
    ""maps"": [
        {
            ""name"": ""PlayerControls"",
            ""id"": ""aa8d5c4e-d75c-4c93-90ec-35e70e98601d"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""2612cf98-8233-4cc4-9f7c-243e56a7ca08"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""YRotation"",
                    ""type"": ""Value"",
                    ""id"": ""7fb6a9a7-13b9-47f8-9225-f95a53317813"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""XRotation"",
                    ""type"": ""Value"",
                    ""id"": ""194a456c-a9ca-490f-9058-4da7359614ce"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""DisableControls"",
                    ""type"": ""Button"",
                    ""id"": ""f850a1e3-965d-4ec2-aaa5-545c9f3ad334"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""EnableControls"",
                    ""type"": ""Button"",
                    ""id"": ""8a3829d0-2eae-4d47-9737-0552d97e9f17"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""MoveAxis"",
                    ""id"": ""c9df4807-04f2-4294-a514-bf09aa61750e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d2efdcfb-3630-4cf6-b603-0a4efcf5b0ab"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""97e1887e-78d2-466f-a379-d03d7a6f7456"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9735c398-0c52-465a-ac41-c01e48451100"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ee42d80b-ebaf-4a37-aa46-a33fd940cca5"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""2376051c-e9ae-4e43-ac06-07413b582424"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""YRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b759109c-a438-47b8-9648-ef37092b3bd3"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DisableControls"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e2c37ad8-f7e8-4225-bf50-0d98f24e3a85"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EnableControls"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""34a95a39-16a7-4865-8292-1c254ad7bd21"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": ""Invert"",
                    ""groups"": """",
                    ""action"": ""XRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Combat"",
            ""id"": ""cf6fe370-65c4-4b46-a655-66e87bc4815f"",
            ""actions"": [
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""91e76833-d529-46a8-ae94-3ffd3ef89df1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d5253535-dbff-44c1-baac-bb84fcdc77c3"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerControls
        m_PlayerControls = asset.FindActionMap("PlayerControls", throwIfNotFound: true);
        m_PlayerControls_Move = m_PlayerControls.FindAction("Move", throwIfNotFound: true);
        m_PlayerControls_YRotation = m_PlayerControls.FindAction("YRotation", throwIfNotFound: true);
        m_PlayerControls_XRotation = m_PlayerControls.FindAction("XRotation", throwIfNotFound: true);
        m_PlayerControls_DisableControls = m_PlayerControls.FindAction("DisableControls", throwIfNotFound: true);
        m_PlayerControls_EnableControls = m_PlayerControls.FindAction("EnableControls", throwIfNotFound: true);
        // Combat
        m_Combat = asset.FindActionMap("Combat", throwIfNotFound: true);
        m_Combat_Shoot = m_Combat.FindAction("Shoot", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // PlayerControls
    private readonly InputActionMap m_PlayerControls;
    private IPlayerControlsActions m_PlayerControlsActionsCallbackInterface;
    private readonly InputAction m_PlayerControls_Move;
    private readonly InputAction m_PlayerControls_YRotation;
    private readonly InputAction m_PlayerControls_XRotation;
    private readonly InputAction m_PlayerControls_DisableControls;
    private readonly InputAction m_PlayerControls_EnableControls;
    public struct PlayerControlsActions
    {
        private @InputsActions m_Wrapper;
        public PlayerControlsActions(@InputsActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerControls_Move;
        public InputAction @YRotation => m_Wrapper.m_PlayerControls_YRotation;
        public InputAction @XRotation => m_Wrapper.m_PlayerControls_XRotation;
        public InputAction @DisableControls => m_Wrapper.m_PlayerControls_DisableControls;
        public InputAction @EnableControls => m_Wrapper.m_PlayerControls_EnableControls;
        public InputActionMap Get() { return m_Wrapper.m_PlayerControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControlsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerControlsActions instance)
        {
            if (m_Wrapper.m_PlayerControlsActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMove;
                @YRotation.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnYRotation;
                @YRotation.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnYRotation;
                @YRotation.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnYRotation;
                @XRotation.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnXRotation;
                @XRotation.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnXRotation;
                @XRotation.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnXRotation;
                @DisableControls.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnDisableControls;
                @DisableControls.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnDisableControls;
                @DisableControls.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnDisableControls;
                @EnableControls.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnEnableControls;
                @EnableControls.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnEnableControls;
                @EnableControls.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnEnableControls;
            }
            m_Wrapper.m_PlayerControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @YRotation.started += instance.OnYRotation;
                @YRotation.performed += instance.OnYRotation;
                @YRotation.canceled += instance.OnYRotation;
                @XRotation.started += instance.OnXRotation;
                @XRotation.performed += instance.OnXRotation;
                @XRotation.canceled += instance.OnXRotation;
                @DisableControls.started += instance.OnDisableControls;
                @DisableControls.performed += instance.OnDisableControls;
                @DisableControls.canceled += instance.OnDisableControls;
                @EnableControls.started += instance.OnEnableControls;
                @EnableControls.performed += instance.OnEnableControls;
                @EnableControls.canceled += instance.OnEnableControls;
            }
        }
    }
    public PlayerControlsActions @PlayerControls => new PlayerControlsActions(this);

    // Combat
    private readonly InputActionMap m_Combat;
    private ICombatActions m_CombatActionsCallbackInterface;
    private readonly InputAction m_Combat_Shoot;
    public struct CombatActions
    {
        private @InputsActions m_Wrapper;
        public CombatActions(@InputsActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shoot => m_Wrapper.m_Combat_Shoot;
        public InputActionMap Get() { return m_Wrapper.m_Combat; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CombatActions set) { return set.Get(); }
        public void SetCallbacks(ICombatActions instance)
        {
            if (m_Wrapper.m_CombatActionsCallbackInterface != null)
            {
                @Shoot.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnShoot;
            }
            m_Wrapper.m_CombatActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
            }
        }
    }
    public CombatActions @Combat => new CombatActions(this);
    public interface IPlayerControlsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnYRotation(InputAction.CallbackContext context);
        void OnXRotation(InputAction.CallbackContext context);
        void OnDisableControls(InputAction.CallbackContext context);
        void OnEnableControls(InputAction.CallbackContext context);
    }
    public interface ICombatActions
    {
        void OnShoot(InputAction.CallbackContext context);
    }
}
