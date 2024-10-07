//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Settings/Input/InputAction.inputactions
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

public partial class @InputAction: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputAction"",
    ""maps"": [
        {
            ""name"": ""InputReader"",
            ""id"": ""0dcf5d58-a466-4506-82d8-ccad61cbca24"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""4c298dd2-a645-440a-bd19-9bd7d0c62c19"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""1620a3a0-0db9-4408-9007-2f852da43689"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Skill1"",
                    ""type"": ""Button"",
                    ""id"": ""c2772b3d-89a6-4cda-9e59-f66800dea4ae"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Skill2"",
                    ""type"": ""Button"",
                    ""id"": ""8664e9e0-3fa4-4854-ad79-c1e8f166a1ff"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SpecialSkill"",
                    ""type"": ""Button"",
                    ""id"": ""18f60842-f44a-4e32-89d4-ec8eb86eda78"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""614d7a0e-aea8-4ee4-8be0-336a5ee5a245"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""3D Vector"",
                    ""id"": ""09bfd96d-b2bb-4a35-bd7d-14bc527ad3c5"",
                    ""path"": ""3DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ca9e9d72-6914-464b-b261-25c617e858f6"",
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
                    ""id"": ""3134762b-f288-431f-9dca-9db725df6f23"",
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
                    ""id"": ""2617f628-d9ec-43f6-9859-b3f70a9f409d"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""27209761-76cb-4994-a2d8-a8f186d1fee9"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5ef23e63-bd7b-4e96-a6b1-89f3c8114776"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpecialSkill"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""MouseAndKeyboard"",
            ""bindingGroup"": ""MouseAndKeyboard"",
            ""devices"": []
        }
    ]
}");
        // InputReader
        m_InputReader = asset.FindActionMap("InputReader", throwIfNotFound: true);
        m_InputReader_Jump = m_InputReader.FindAction("Jump", throwIfNotFound: true);
        m_InputReader_Move = m_InputReader.FindAction("Move", throwIfNotFound: true);
        m_InputReader_Skill1 = m_InputReader.FindAction("Skill1", throwIfNotFound: true);
        m_InputReader_Skill2 = m_InputReader.FindAction("Skill2", throwIfNotFound: true);
        m_InputReader_SpecialSkill = m_InputReader.FindAction("SpecialSkill", throwIfNotFound: true);
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

    // InputReader
    private readonly InputActionMap m_InputReader;
    private List<IInputReaderActions> m_InputReaderActionsCallbackInterfaces = new List<IInputReaderActions>();
    private readonly InputAction m_InputReader_Jump;
    private readonly InputAction m_InputReader_Move;
    private readonly InputAction m_InputReader_Skill1;
    private readonly InputAction m_InputReader_Skill2;
    private readonly InputAction m_InputReader_SpecialSkill;
    public struct InputReaderActions
    {
        private @InputAction m_Wrapper;
        public InputReaderActions(@InputAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_InputReader_Jump;
        public InputAction @Move => m_Wrapper.m_InputReader_Move;
        public InputAction @Skill1 => m_Wrapper.m_InputReader_Skill1;
        public InputAction @Skill2 => m_Wrapper.m_InputReader_Skill2;
        public InputAction @SpecialSkill => m_Wrapper.m_InputReader_SpecialSkill;
        public InputActionMap Get() { return m_Wrapper.m_InputReader; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InputReaderActions set) { return set.Get(); }
        public void AddCallbacks(IInputReaderActions instance)
        {
            if (instance == null || m_Wrapper.m_InputReaderActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_InputReaderActionsCallbackInterfaces.Add(instance);
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Skill1.started += instance.OnSkill1;
            @Skill1.performed += instance.OnSkill1;
            @Skill1.canceled += instance.OnSkill1;
            @Skill2.started += instance.OnSkill2;
            @Skill2.performed += instance.OnSkill2;
            @Skill2.canceled += instance.OnSkill2;
            @SpecialSkill.started += instance.OnSpecialSkill;
            @SpecialSkill.performed += instance.OnSpecialSkill;
            @SpecialSkill.canceled += instance.OnSpecialSkill;
        }

        private void UnregisterCallbacks(IInputReaderActions instance)
        {
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Skill1.started -= instance.OnSkill1;
            @Skill1.performed -= instance.OnSkill1;
            @Skill1.canceled -= instance.OnSkill1;
            @Skill2.started -= instance.OnSkill2;
            @Skill2.performed -= instance.OnSkill2;
            @Skill2.canceled -= instance.OnSkill2;
            @SpecialSkill.started -= instance.OnSpecialSkill;
            @SpecialSkill.performed -= instance.OnSpecialSkill;
            @SpecialSkill.canceled -= instance.OnSpecialSkill;
        }

        public void RemoveCallbacks(IInputReaderActions instance)
        {
            if (m_Wrapper.m_InputReaderActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IInputReaderActions instance)
        {
            foreach (var item in m_Wrapper.m_InputReaderActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_InputReaderActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public InputReaderActions @InputReader => new InputReaderActions(this);
    private int m_MouseAndKeyboardSchemeIndex = -1;
    public InputControlScheme MouseAndKeyboardScheme
    {
        get
        {
            if (m_MouseAndKeyboardSchemeIndex == -1) m_MouseAndKeyboardSchemeIndex = asset.FindControlSchemeIndex("MouseAndKeyboard");
            return asset.controlSchemes[m_MouseAndKeyboardSchemeIndex];
        }
    }
    public interface IInputReaderActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnSkill1(InputAction.CallbackContext context);
        void OnSkill2(InputAction.CallbackContext context);
        void OnSpecialSkill(InputAction.CallbackContext context);
    }
}