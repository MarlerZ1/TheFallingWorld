//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/InputSystem/Controls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Controls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Move"",
            ""id"": ""afc1be84-4d1a-4b59-aa0e-c66df70a6e7c"",
            ""actions"": [
                {
                    ""name"": ""Moving"",
                    ""type"": ""Value"",
                    ""id"": ""b9e40628-7784-40e0-9a51-7a432fc8629d"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jumping"",
                    ""type"": ""Button"",
                    ""id"": ""1b16ff8a-7f3c-43aa-8c88-a91ac830bc8f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""HorizontalMove"",
                    ""id"": ""7bb77a3a-95aa-4d1f-a0be-b6a0de402666"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""be071043-ae67-410d-a69d-ac5b73c5b268"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Moving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""2c2e55cb-4dea-4ec0-9dbe-3833e4a9ebe8"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Moving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""91befe1c-1d1b-4c31-a8fb-6504f56e79ae"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Jumping"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Attack"",
            ""id"": ""097869cc-1a81-4e24-99e4-b5c121596ffb"",
            ""actions"": [
                {
                    ""name"": ""Magic"",
                    ""type"": ""Button"",
                    ""id"": ""6a8784a3-c82c-41e5-8bc7-674979105560"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Sword"",
                    ""type"": ""Button"",
                    ""id"": ""0352bb95-f5bc-4ec9-87ea-2dd320113cf5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""AttackDirection"",
                    ""type"": ""Value"",
                    ""id"": ""0ea5a6f4-99ad-41e7-92fe-6589ecf8ca4c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""52cef5f3-fd37-45ca-bc0f-210932cb17ae"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""66cf08a4-f93d-42b5-bb79-0ee0f7c05f2f"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Magic"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""903206ca-ea13-4c8e-9e14-53a73a015f86"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Sword"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ecae08b1-7571-4863-9f2a-8bb5512fb395"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""AttackDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""59ab62e8-d36d-4275-932f-e4135469c618"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""d89af756-5e17-4d51-b120-87fa6dbeb944"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""1bd447c3-4d04-4507-a5f3-e4771a70e0d3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d201ec4f-83e8-40e9-bfdb-004d365a47fb"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""PC"",
            ""bindingGroup"": ""PC"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Move
        m_Move = asset.FindActionMap("Move", throwIfNotFound: true);
        m_Move_Moving = m_Move.FindAction("Moving", throwIfNotFound: true);
        m_Move_Jumping = m_Move.FindAction("Jumping", throwIfNotFound: true);
        // Attack
        m_Attack = asset.FindActionMap("Attack", throwIfNotFound: true);
        m_Attack_Magic = m_Attack.FindAction("Magic", throwIfNotFound: true);
        m_Attack_Sword = m_Attack.FindAction("Sword", throwIfNotFound: true);
        m_Attack_AttackDirection = m_Attack.FindAction("AttackDirection", throwIfNotFound: true);
        m_Attack_Reload = m_Attack.FindAction("Reload", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Pause = m_UI.FindAction("Pause", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Move
    private readonly InputActionMap m_Move;
    private List<IMoveActions> m_MoveActionsCallbackInterfaces = new List<IMoveActions>();
    private readonly InputAction m_Move_Moving;
    private readonly InputAction m_Move_Jumping;
    public struct MoveActions
    {
        private @Controls m_Wrapper;
        public MoveActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Moving => m_Wrapper.m_Move_Moving;
        public InputAction @Jumping => m_Wrapper.m_Move_Jumping;
        public InputActionMap Get() { return m_Wrapper.m_Move; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MoveActions set) { return set.Get(); }
        public void AddCallbacks(IMoveActions instance)
        {
            if (instance == null || m_Wrapper.m_MoveActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MoveActionsCallbackInterfaces.Add(instance);
            @Moving.started += instance.OnMoving;
            @Moving.performed += instance.OnMoving;
            @Moving.canceled += instance.OnMoving;
            @Jumping.started += instance.OnJumping;
            @Jumping.performed += instance.OnJumping;
            @Jumping.canceled += instance.OnJumping;
        }

        private void UnregisterCallbacks(IMoveActions instance)
        {
            @Moving.started -= instance.OnMoving;
            @Moving.performed -= instance.OnMoving;
            @Moving.canceled -= instance.OnMoving;
            @Jumping.started -= instance.OnJumping;
            @Jumping.performed -= instance.OnJumping;
            @Jumping.canceled -= instance.OnJumping;
        }

        public void RemoveCallbacks(IMoveActions instance)
        {
            if (m_Wrapper.m_MoveActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMoveActions instance)
        {
            foreach (var item in m_Wrapper.m_MoveActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MoveActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MoveActions @Move => new MoveActions(this);

    // Attack
    private readonly InputActionMap m_Attack;
    private List<IAttackActions> m_AttackActionsCallbackInterfaces = new List<IAttackActions>();
    private readonly InputAction m_Attack_Magic;
    private readonly InputAction m_Attack_Sword;
    private readonly InputAction m_Attack_AttackDirection;
    private readonly InputAction m_Attack_Reload;
    public struct AttackActions
    {
        private @Controls m_Wrapper;
        public AttackActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Magic => m_Wrapper.m_Attack_Magic;
        public InputAction @Sword => m_Wrapper.m_Attack_Sword;
        public InputAction @AttackDirection => m_Wrapper.m_Attack_AttackDirection;
        public InputAction @Reload => m_Wrapper.m_Attack_Reload;
        public InputActionMap Get() { return m_Wrapper.m_Attack; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AttackActions set) { return set.Get(); }
        public void AddCallbacks(IAttackActions instance)
        {
            if (instance == null || m_Wrapper.m_AttackActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_AttackActionsCallbackInterfaces.Add(instance);
            @Magic.started += instance.OnMagic;
            @Magic.performed += instance.OnMagic;
            @Magic.canceled += instance.OnMagic;
            @Sword.started += instance.OnSword;
            @Sword.performed += instance.OnSword;
            @Sword.canceled += instance.OnSword;
            @AttackDirection.started += instance.OnAttackDirection;
            @AttackDirection.performed += instance.OnAttackDirection;
            @AttackDirection.canceled += instance.OnAttackDirection;
            @Reload.started += instance.OnReload;
            @Reload.performed += instance.OnReload;
            @Reload.canceled += instance.OnReload;
        }

        private void UnregisterCallbacks(IAttackActions instance)
        {
            @Magic.started -= instance.OnMagic;
            @Magic.performed -= instance.OnMagic;
            @Magic.canceled -= instance.OnMagic;
            @Sword.started -= instance.OnSword;
            @Sword.performed -= instance.OnSword;
            @Sword.canceled -= instance.OnSword;
            @AttackDirection.started -= instance.OnAttackDirection;
            @AttackDirection.performed -= instance.OnAttackDirection;
            @AttackDirection.canceled -= instance.OnAttackDirection;
            @Reload.started -= instance.OnReload;
            @Reload.performed -= instance.OnReload;
            @Reload.canceled -= instance.OnReload;
        }

        public void RemoveCallbacks(IAttackActions instance)
        {
            if (m_Wrapper.m_AttackActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IAttackActions instance)
        {
            foreach (var item in m_Wrapper.m_AttackActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_AttackActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public AttackActions @Attack => new AttackActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private List<IUIActions> m_UIActionsCallbackInterfaces = new List<IUIActions>();
    private readonly InputAction m_UI_Pause;
    public struct UIActions
    {
        private @Controls m_Wrapper;
        public UIActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_UI_Pause;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void AddCallbacks(IUIActions instance)
        {
            if (instance == null || m_Wrapper.m_UIActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_UIActionsCallbackInterfaces.Add(instance);
            @Pause.started += instance.OnPause;
            @Pause.performed += instance.OnPause;
            @Pause.canceled += instance.OnPause;
        }

        private void UnregisterCallbacks(IUIActions instance)
        {
            @Pause.started -= instance.OnPause;
            @Pause.performed -= instance.OnPause;
            @Pause.canceled -= instance.OnPause;
        }

        public void RemoveCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IUIActions instance)
        {
            foreach (var item in m_Wrapper.m_UIActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_UIActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public UIActions @UI => new UIActions(this);
    private int m_PCSchemeIndex = -1;
    public InputControlScheme PCScheme
    {
        get
        {
            if (m_PCSchemeIndex == -1) m_PCSchemeIndex = asset.FindControlSchemeIndex("PC");
            return asset.controlSchemes[m_PCSchemeIndex];
        }
    }
    public interface IMoveActions
    {
        void OnMoving(InputAction.CallbackContext context);
        void OnJumping(InputAction.CallbackContext context);
    }
    public interface IAttackActions
    {
        void OnMagic(InputAction.CallbackContext context);
        void OnSword(InputAction.CallbackContext context);
        void OnAttackDirection(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnPause(InputAction.CallbackContext context);
    }
}
