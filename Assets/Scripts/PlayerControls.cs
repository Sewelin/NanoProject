// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""019fbc32-de5c-44bd-a684-423d1b15cc35"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""e4f914b1-af6b-46f5-915a-1df70c4fd7ad"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""VerticalAttack"",
                    ""type"": ""Button"",
                    ""id"": ""b4c780f3-b70f-4996-9072-7e7437348edd"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DashAttack"",
                    ""type"": ""Button"",
                    ""id"": ""4ade17c9-d256-4762-a730-020933874a23"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""e12f321d-c7e5-4985-b49e-be36bb1c20ab"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""BackDash"",
                    ""type"": ""Button"",
                    ""id"": ""6d43231c-b668-4f88-9ab2-eb157eab3569"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Bow"",
                    ""type"": ""Button"",
                    ""id"": ""ad664fc9-a4ab-4387-b10a-75254d6afca7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2392534c-b3ce-4207-a977-f49ad6f48c83"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4be66b2e-7866-4697-8e0a-a97d002a4c99"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DashAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6f443da9-0966-408a-b282-43a715b9bedb"",
                    ""path"": ""<Gamepad>/leftStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fa3a1ba6-4b15-40f3-ab1f-7659ed0cbd98"",
                    ""path"": ""<Gamepad>/dpad/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""740ceb65-652c-41b4-bf76-97f502bc2514"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""76a1d54c-1007-4720-b444-3f1f349147c3"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BackDash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0abec7b2-e78b-421f-b72f-1ea0a07cd513"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BackDash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5812e171-40ff-4f8e-9d64-253697217c1b"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Bow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Pause = m_Gameplay.FindAction("Pause", throwIfNotFound: true);
        m_Gameplay_VerticalAttack = m_Gameplay.FindAction("VerticalAttack", throwIfNotFound: true);
        m_Gameplay_DashAttack = m_Gameplay.FindAction("DashAttack", throwIfNotFound: true);
        m_Gameplay_Movement = m_Gameplay.FindAction("Movement", throwIfNotFound: true);
        m_Gameplay_BackDash = m_Gameplay.FindAction("BackDash", throwIfNotFound: true);
        m_Gameplay_Bow = m_Gameplay.FindAction("Bow", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Pause;
    private readonly InputAction m_Gameplay_VerticalAttack;
    private readonly InputAction m_Gameplay_DashAttack;
    private readonly InputAction m_Gameplay_Movement;
    private readonly InputAction m_Gameplay_BackDash;
    private readonly InputAction m_Gameplay_Bow;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_Gameplay_Pause;
        public InputAction @VerticalAttack => m_Wrapper.m_Gameplay_VerticalAttack;
        public InputAction @DashAttack => m_Wrapper.m_Gameplay_DashAttack;
        public InputAction @Movement => m_Wrapper.m_Gameplay_Movement;
        public InputAction @BackDash => m_Wrapper.m_Gameplay_BackDash;
        public InputAction @Bow => m_Wrapper.m_Gameplay_Bow;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @VerticalAttack.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnVerticalAttack;
                @VerticalAttack.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnVerticalAttack;
                @VerticalAttack.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnVerticalAttack;
                @DashAttack.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDashAttack;
                @DashAttack.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDashAttack;
                @DashAttack.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDashAttack;
                @Movement.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @BackDash.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBackDash;
                @BackDash.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBackDash;
                @BackDash.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBackDash;
                @Bow.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBow;
                @Bow.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBow;
                @Bow.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBow;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @VerticalAttack.started += instance.OnVerticalAttack;
                @VerticalAttack.performed += instance.OnVerticalAttack;
                @VerticalAttack.canceled += instance.OnVerticalAttack;
                @DashAttack.started += instance.OnDashAttack;
                @DashAttack.performed += instance.OnDashAttack;
                @DashAttack.canceled += instance.OnDashAttack;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @BackDash.started += instance.OnBackDash;
                @BackDash.performed += instance.OnBackDash;
                @BackDash.canceled += instance.OnBackDash;
                @Bow.started += instance.OnBow;
                @Bow.performed += instance.OnBow;
                @Bow.canceled += instance.OnBow;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnPause(InputAction.CallbackContext context);
        void OnVerticalAttack(InputAction.CallbackContext context);
        void OnDashAttack(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnBackDash(InputAction.CallbackContext context);
        void OnBow(InputAction.CallbackContext context);
    }
}
