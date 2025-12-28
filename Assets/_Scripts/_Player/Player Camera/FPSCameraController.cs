using System;
using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.InputSystem;

public class FPSCameraController : InputAxisControllerBase<FPSCameraController.Reader>
{
    [Header("Input Source Override")]
    public PlayerInput playerInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (playerInput == null)
            TryGetComponent(out playerInput);
        if (playerInput == null)
            Debug.LogError("Cannot find PlayerInput component");
        else
        {
            playerInput.notificationBehavior = PlayerNotifications.InvokeCSharpEvents;
            playerInput.onActionTriggered += (value) =>
            {
                for (var i = 0; i < Controllers.Count; i++)
                    Controllers[i].Input.ProcessInput(value.action);
            };
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [Serializable]
    public class Reader : IInputAxisReader
    {
        public InputActionReference Input;
        private Vector2 m_Value; // the cached value of the input

        public void ProcessInput(InputAction action)
        {
            if (Input != null && Input.action.id == action.id)
            {
                // If it's my action then cache the new value
                if (action.expectedControlType == "Vector2")
                    m_Value = action.ReadValue<Vector2>();
                else
                    m_Value.x = m_Value.y = action.ReadValue<float>();
            }
        }

        // IInputAxisReader interface: Called by the framework to read the input value
        public float GetValue(UnityEngine.Object context, IInputAxisOwner.AxisDescriptor.Hints hint)
        {
            return (hint == IInputAxisOwner.AxisDescriptor.Hints.Y ? m_Value.y : m_Value.x);
        }
    }
}
