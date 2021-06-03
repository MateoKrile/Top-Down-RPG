// GENERATED AUTOMATICALLY FROM 'Assets/Input system/Player Controls.inputactions'

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
    ""name"": ""Player Controls"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""0b9e4088-c883-4ccd-894b-0c97b28043c4"",
            ""actions"": [
                {
                    ""name"": ""GoTo"",
                    ""type"": ""Button"",
                    ""id"": ""e78c2773-5e4c-47fd-89ed-fffbddd5809a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3b3c07e3-dab5-4023-bd19-aefda74cff37"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PointAndClick"",
                    ""action"": ""GoTo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""PointAndClick"",
            ""bindingGroup"": ""PointAndClick"",
            ""devices"": []
        }
    ]
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_GoTo = m_Movement.FindAction("GoTo", throwIfNotFound: true);
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

    // Movement
    private readonly InputActionMap m_Movement;
    private IMovementActions m_MovementActionsCallbackInterface;
    private readonly InputAction m_Movement_GoTo;
    public struct MovementActions
    {
        private @PlayerControls m_Wrapper;
        public MovementActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @GoTo => m_Wrapper.m_Movement_GoTo;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                @GoTo.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnGoTo;
                @GoTo.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnGoTo;
                @GoTo.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnGoTo;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @GoTo.started += instance.OnGoTo;
                @GoTo.performed += instance.OnGoTo;
                @GoTo.canceled += instance.OnGoTo;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);
    private int m_PointAndClickSchemeIndex = -1;
    public InputControlScheme PointAndClickScheme
    {
        get
        {
            if (m_PointAndClickSchemeIndex == -1) m_PointAndClickSchemeIndex = asset.FindControlSchemeIndex("PointAndClick");
            return asset.controlSchemes[m_PointAndClickSchemeIndex];
        }
    }
    public interface IMovementActions
    {
        void OnGoTo(InputAction.CallbackContext context);
    }
}
