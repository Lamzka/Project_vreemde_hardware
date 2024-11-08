//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.8.1
//     from Assets/Development/Raymond/test.inputactions
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
using UnityEngine;

public partial class @TestingInputSystem: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @TestingInputSystem()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""test"",
    ""maps"": [
        {
            ""name"": ""Wheel"",
            ""id"": ""dd128165-c3e2-4d78-b373-11f230b20690"",
            ""actions"": [
                {
                    ""name"": ""Steering Wheel"",
                    ""type"": ""Value"",
                    ""id"": ""e11f018e-34a0-4274-b6d2-8717cb61905c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Directions"",
                    ""id"": ""bd8d322d-d347-46b8-8ffa-1c72aa96e30a"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steering Wheel"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""1e099702-5df4-41cc-9a3f-1c2534f754d1"",
                    ""path"": ""<HID::Logitech G29 Driving Force Racing Wheel>/stick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steering Wheel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""451ede6d-02e5-4419-b869-f8501ca6df5b"",
                    ""path"": ""<HID::Logitech G29 Driving Force Racing Wheel>/stick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steering Wheel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Wheel
        m_Wheel = asset.FindActionMap("Wheel", throwIfNotFound: true);
        m_Wheel_SteeringWheel = m_Wheel.FindAction("Steering Wheel", throwIfNotFound: true);
    }

    ~@TestingInputSystem()
    {
        Debug.Assert(!m_Wheel.enabled, "This will cause a leak and performance issues, TestingInputSystem.Wheel.Disable() has not been called.");
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

    // Wheel
    private readonly InputActionMap m_Wheel;
    private List<IWheelActions> m_WheelActionsCallbackInterfaces = new List<IWheelActions>();
    private readonly InputAction m_Wheel_SteeringWheel;
    public struct WheelActions
    {
        private @TestingInputSystem m_Wrapper;
        public WheelActions(@TestingInputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @SteeringWheel => m_Wrapper.m_Wheel_SteeringWheel;
        public InputActionMap Get() { return m_Wrapper.m_Wheel; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(WheelActions set) { return set.Get(); }
        public void AddCallbacks(IWheelActions instance)
        {
            if (instance == null || m_Wrapper.m_WheelActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_WheelActionsCallbackInterfaces.Add(instance);
            @SteeringWheel.started += instance.OnSteeringWheel;
            @SteeringWheel.performed += instance.OnSteeringWheel;
            @SteeringWheel.canceled += instance.OnSteeringWheel;
        }

        private void UnregisterCallbacks(IWheelActions instance)
        {
            @SteeringWheel.started -= instance.OnSteeringWheel;
            @SteeringWheel.performed -= instance.OnSteeringWheel;
            @SteeringWheel.canceled -= instance.OnSteeringWheel;
        }

        public void RemoveCallbacks(IWheelActions instance)
        {
            if (m_Wrapper.m_WheelActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IWheelActions instance)
        {
            foreach (var item in m_Wrapper.m_WheelActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_WheelActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public WheelActions @Wheel => new WheelActions(this);
    public interface IWheelActions
    {
        void OnSteeringWheel(InputAction.CallbackContext context);
    }
}
