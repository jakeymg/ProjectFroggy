// GENERATED AUTOMATICALLY FROM 'Assets/Settings/Controllers/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""085fbc0f-e366-4923-ba97-84646946ee1e"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""b657029b-c23e-45f4-8f2d-a647d1e5efca"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraShift"",
                    ""type"": ""Value"",
                    ""id"": ""50467cf6-b6b1-4fdf-82a2-12efc00e156c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""EastButton"",
                    ""type"": ""Button"",
                    ""id"": ""d77ef43e-e5ff-40a5-95e1-ac53fbab6bad"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SouthButton"",
                    ""type"": ""Button"",
                    ""id"": ""2d3f39c3-7849-4976-9346-371750cf0b44"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""WestButton"",
                    ""type"": ""Button"",
                    ""id"": ""c8ac2651-fc08-458a-a828-d584a467e31b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NorthButton"",
                    ""type"": ""Button"",
                    ""id"": ""c64b1246-d191-45b9-8a16-15ad3d4d91c8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""11bb38e7-bfe8-4016-8f17-d33865577469"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""8461477d-7ed9-496f-a958-a44b7a0b273f"",
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
                    ""id"": ""f9c59627-6f20-4298-99c7-35e5fb75283f"",
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
                    ""id"": ""4b22d53f-9937-47c6-b3e3-a47d646f2e47"",
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
                    ""id"": ""a8e48aff-e2c0-4e69-8dca-c6406ef92adb"",
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
                    ""id"": ""a757134a-ef03-4d97-9ba0-23f14ca38dd5"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""ArrowKeys"",
                    ""id"": ""00e5e714-4973-443b-8772-94eae6d22b0b"",
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
                    ""id"": ""887ba2d4-b920-41e9-93c0-67a673504fea"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3feab283-76d5-411b-940e-19bf38bf6cd9"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""77cda987-72ba-4fe2-b88e-b881ff5922b7"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d24018f2-8ec0-4927-ba6b-2f9665af9666"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""60aaac27-8803-4b62-9006-89f5f7d5fb1c"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""51fe8d03-433b-408b-ba86-89848ce1b0f9"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EastButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1b1e2188-cb3c-4c4e-b2ef-2f810fbf62d1"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EastButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3d2c6dbd-d3ef-42fe-8aac-fc78b6387ce9"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SouthButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c75e726b-4f4b-44af-ab60-689c03f8607c"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SouthButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f287365b-d8aa-4d35-9d94-515e2d8f4b20"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WestButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""81a3b3c4-fb61-44dc-a351-b19357f53ac8"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NorthButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7e5b41ca-16fd-4415-9452-51d25d9cdb46"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraShift"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""BattleControls"",
            ""id"": ""9a9b8a24-129f-4ac2-8f94-d719bbbfe346"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""841e4b9c-011e-4000-a77d-70b715809286"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""EastButton"",
                    ""type"": ""Button"",
                    ""id"": ""c23eed4c-c78a-4214-84e9-a26dc67db9e0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SouthButton"",
                    ""type"": ""Button"",
                    ""id"": ""732e3733-91f4-49dd-9b5e-57dfe6c25623"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""WestButton"",
                    ""type"": ""Button"",
                    ""id"": ""4bfe0df4-8985-4421-aff0-9aa57a21b75e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NorthButton"",
                    ""type"": ""Button"",
                    ""id"": ""ba8f5336-cd63-49dc-8b4c-d32b2e7468f7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightTrigger"",
                    ""type"": ""Button"",
                    ""id"": ""6ac5543b-79cd-483f-b971-c3f186a73c95"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftTrigger"",
                    ""type"": ""Button"",
                    ""id"": ""1d8c5eae-63c9-4a4c-bc64-775bad3b5b8f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StartButton"",
                    ""type"": ""Button"",
                    ""id"": ""a1c026ad-29c0-4a37-a053-bd1fe5311ebe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f37a04c3-850f-4eb5-87bb-355cc657479e"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""50f5df84-373d-4bcb-8e88-31e1be7e8436"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""ArrowKeys"",
                    ""id"": ""fa29e8e3-7785-4aff-89b1-6ee6eb875ea0"",
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
                    ""id"": ""95527e3a-b683-4fd7-a9e7-a127d40bc74d"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""cd518cbd-3940-497f-b0fb-d9137875738f"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f9c077ca-2ddd-4770-8fd3-46366f9e6b33"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e780ac5b-2a22-425a-b72b-394cc83739ff"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""72c784b6-427f-41cf-be95-f344d8151a4c"",
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
                    ""id"": ""4d335c7a-d847-42ec-8a70-522b7c269811"",
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
                    ""id"": ""510d63ff-d187-4577-96d6-76df253f74f1"",
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
                    ""id"": ""3104fdfc-4533-4bb7-9726-9181a9c714a3"",
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
                    ""id"": ""ebd86379-31e4-4f11-b1cd-9ca125b698d3"",
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
                    ""id"": ""fbedae8b-9e81-496e-b9f3-e899faef53ca"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EastButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9e216f6b-c7d9-49da-90a1-156f4857aef5"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SouthButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0584af1d-e8b3-443e-9f2e-ad73e0af7055"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WestButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""70af8707-5a26-47d1-8216-431a4f13eec2"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NorthButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a1eb4f0f-f631-4317-a96d-b9b048dbbe57"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightTrigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9e493401-4c47-40e1-ad65-388fe929e8c1"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftTrigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4c55f4fc-dae2-43f6-9810-feb372567098"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartButton"",
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
        m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
        m_Gameplay_CameraShift = m_Gameplay.FindAction("CameraShift", throwIfNotFound: true);
        m_Gameplay_EastButton = m_Gameplay.FindAction("EastButton", throwIfNotFound: true);
        m_Gameplay_SouthButton = m_Gameplay.FindAction("SouthButton", throwIfNotFound: true);
        m_Gameplay_WestButton = m_Gameplay.FindAction("WestButton", throwIfNotFound: true);
        m_Gameplay_NorthButton = m_Gameplay.FindAction("NorthButton", throwIfNotFound: true);
        // BattleControls
        m_BattleControls = asset.FindActionMap("BattleControls", throwIfNotFound: true);
        m_BattleControls_Move = m_BattleControls.FindAction("Move", throwIfNotFound: true);
        m_BattleControls_EastButton = m_BattleControls.FindAction("EastButton", throwIfNotFound: true);
        m_BattleControls_SouthButton = m_BattleControls.FindAction("SouthButton", throwIfNotFound: true);
        m_BattleControls_WestButton = m_BattleControls.FindAction("WestButton", throwIfNotFound: true);
        m_BattleControls_NorthButton = m_BattleControls.FindAction("NorthButton", throwIfNotFound: true);
        m_BattleControls_RightTrigger = m_BattleControls.FindAction("RightTrigger", throwIfNotFound: true);
        m_BattleControls_LeftTrigger = m_BattleControls.FindAction("LeftTrigger", throwIfNotFound: true);
        m_BattleControls_StartButton = m_BattleControls.FindAction("StartButton", throwIfNotFound: true);
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
    private readonly InputAction m_Gameplay_Move;
    private readonly InputAction m_Gameplay_CameraShift;
    private readonly InputAction m_Gameplay_EastButton;
    private readonly InputAction m_Gameplay_SouthButton;
    private readonly InputAction m_Gameplay_WestButton;
    private readonly InputAction m_Gameplay_NorthButton;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Gameplay_Move;
        public InputAction @CameraShift => m_Wrapper.m_Gameplay_CameraShift;
        public InputAction @EastButton => m_Wrapper.m_Gameplay_EastButton;
        public InputAction @SouthButton => m_Wrapper.m_Gameplay_SouthButton;
        public InputAction @WestButton => m_Wrapper.m_Gameplay_WestButton;
        public InputAction @NorthButton => m_Wrapper.m_Gameplay_NorthButton;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @CameraShift.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCameraShift;
                @CameraShift.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCameraShift;
                @CameraShift.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCameraShift;
                @EastButton.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEastButton;
                @EastButton.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEastButton;
                @EastButton.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEastButton;
                @SouthButton.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSouthButton;
                @SouthButton.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSouthButton;
                @SouthButton.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSouthButton;
                @WestButton.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnWestButton;
                @WestButton.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnWestButton;
                @WestButton.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnWestButton;
                @NorthButton.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnNorthButton;
                @NorthButton.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnNorthButton;
                @NorthButton.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnNorthButton;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @CameraShift.started += instance.OnCameraShift;
                @CameraShift.performed += instance.OnCameraShift;
                @CameraShift.canceled += instance.OnCameraShift;
                @EastButton.started += instance.OnEastButton;
                @EastButton.performed += instance.OnEastButton;
                @EastButton.canceled += instance.OnEastButton;
                @SouthButton.started += instance.OnSouthButton;
                @SouthButton.performed += instance.OnSouthButton;
                @SouthButton.canceled += instance.OnSouthButton;
                @WestButton.started += instance.OnWestButton;
                @WestButton.performed += instance.OnWestButton;
                @WestButton.canceled += instance.OnWestButton;
                @NorthButton.started += instance.OnNorthButton;
                @NorthButton.performed += instance.OnNorthButton;
                @NorthButton.canceled += instance.OnNorthButton;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // BattleControls
    private readonly InputActionMap m_BattleControls;
    private IBattleControlsActions m_BattleControlsActionsCallbackInterface;
    private readonly InputAction m_BattleControls_Move;
    private readonly InputAction m_BattleControls_EastButton;
    private readonly InputAction m_BattleControls_SouthButton;
    private readonly InputAction m_BattleControls_WestButton;
    private readonly InputAction m_BattleControls_NorthButton;
    private readonly InputAction m_BattleControls_RightTrigger;
    private readonly InputAction m_BattleControls_LeftTrigger;
    private readonly InputAction m_BattleControls_StartButton;
    public struct BattleControlsActions
    {
        private @PlayerControls m_Wrapper;
        public BattleControlsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_BattleControls_Move;
        public InputAction @EastButton => m_Wrapper.m_BattleControls_EastButton;
        public InputAction @SouthButton => m_Wrapper.m_BattleControls_SouthButton;
        public InputAction @WestButton => m_Wrapper.m_BattleControls_WestButton;
        public InputAction @NorthButton => m_Wrapper.m_BattleControls_NorthButton;
        public InputAction @RightTrigger => m_Wrapper.m_BattleControls_RightTrigger;
        public InputAction @LeftTrigger => m_Wrapper.m_BattleControls_LeftTrigger;
        public InputAction @StartButton => m_Wrapper.m_BattleControls_StartButton;
        public InputActionMap Get() { return m_Wrapper.m_BattleControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BattleControlsActions set) { return set.Get(); }
        public void SetCallbacks(IBattleControlsActions instance)
        {
            if (m_Wrapper.m_BattleControlsActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_BattleControlsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_BattleControlsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_BattleControlsActionsCallbackInterface.OnMove;
                @EastButton.started -= m_Wrapper.m_BattleControlsActionsCallbackInterface.OnEastButton;
                @EastButton.performed -= m_Wrapper.m_BattleControlsActionsCallbackInterface.OnEastButton;
                @EastButton.canceled -= m_Wrapper.m_BattleControlsActionsCallbackInterface.OnEastButton;
                @SouthButton.started -= m_Wrapper.m_BattleControlsActionsCallbackInterface.OnSouthButton;
                @SouthButton.performed -= m_Wrapper.m_BattleControlsActionsCallbackInterface.OnSouthButton;
                @SouthButton.canceled -= m_Wrapper.m_BattleControlsActionsCallbackInterface.OnSouthButton;
                @WestButton.started -= m_Wrapper.m_BattleControlsActionsCallbackInterface.OnWestButton;
                @WestButton.performed -= m_Wrapper.m_BattleControlsActionsCallbackInterface.OnWestButton;
                @WestButton.canceled -= m_Wrapper.m_BattleControlsActionsCallbackInterface.OnWestButton;
                @NorthButton.started -= m_Wrapper.m_BattleControlsActionsCallbackInterface.OnNorthButton;
                @NorthButton.performed -= m_Wrapper.m_BattleControlsActionsCallbackInterface.OnNorthButton;
                @NorthButton.canceled -= m_Wrapper.m_BattleControlsActionsCallbackInterface.OnNorthButton;
                @RightTrigger.started -= m_Wrapper.m_BattleControlsActionsCallbackInterface.OnRightTrigger;
                @RightTrigger.performed -= m_Wrapper.m_BattleControlsActionsCallbackInterface.OnRightTrigger;
                @RightTrigger.canceled -= m_Wrapper.m_BattleControlsActionsCallbackInterface.OnRightTrigger;
                @LeftTrigger.started -= m_Wrapper.m_BattleControlsActionsCallbackInterface.OnLeftTrigger;
                @LeftTrigger.performed -= m_Wrapper.m_BattleControlsActionsCallbackInterface.OnLeftTrigger;
                @LeftTrigger.canceled -= m_Wrapper.m_BattleControlsActionsCallbackInterface.OnLeftTrigger;
                @StartButton.started -= m_Wrapper.m_BattleControlsActionsCallbackInterface.OnStartButton;
                @StartButton.performed -= m_Wrapper.m_BattleControlsActionsCallbackInterface.OnStartButton;
                @StartButton.canceled -= m_Wrapper.m_BattleControlsActionsCallbackInterface.OnStartButton;
            }
            m_Wrapper.m_BattleControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @EastButton.started += instance.OnEastButton;
                @EastButton.performed += instance.OnEastButton;
                @EastButton.canceled += instance.OnEastButton;
                @SouthButton.started += instance.OnSouthButton;
                @SouthButton.performed += instance.OnSouthButton;
                @SouthButton.canceled += instance.OnSouthButton;
                @WestButton.started += instance.OnWestButton;
                @WestButton.performed += instance.OnWestButton;
                @WestButton.canceled += instance.OnWestButton;
                @NorthButton.started += instance.OnNorthButton;
                @NorthButton.performed += instance.OnNorthButton;
                @NorthButton.canceled += instance.OnNorthButton;
                @RightTrigger.started += instance.OnRightTrigger;
                @RightTrigger.performed += instance.OnRightTrigger;
                @RightTrigger.canceled += instance.OnRightTrigger;
                @LeftTrigger.started += instance.OnLeftTrigger;
                @LeftTrigger.performed += instance.OnLeftTrigger;
                @LeftTrigger.canceled += instance.OnLeftTrigger;
                @StartButton.started += instance.OnStartButton;
                @StartButton.performed += instance.OnStartButton;
                @StartButton.canceled += instance.OnStartButton;
            }
        }
    }
    public BattleControlsActions @BattleControls => new BattleControlsActions(this);
    public interface IGameplayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnCameraShift(InputAction.CallbackContext context);
        void OnEastButton(InputAction.CallbackContext context);
        void OnSouthButton(InputAction.CallbackContext context);
        void OnWestButton(InputAction.CallbackContext context);
        void OnNorthButton(InputAction.CallbackContext context);
    }
    public interface IBattleControlsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnEastButton(InputAction.CallbackContext context);
        void OnSouthButton(InputAction.CallbackContext context);
        void OnWestButton(InputAction.CallbackContext context);
        void OnNorthButton(InputAction.CallbackContext context);
        void OnRightTrigger(InputAction.CallbackContext context);
        void OnLeftTrigger(InputAction.CallbackContext context);
        void OnStartButton(InputAction.CallbackContext context);
    }
}
