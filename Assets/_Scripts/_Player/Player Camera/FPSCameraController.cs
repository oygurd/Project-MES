using System;
using Sirenix.OdinInspector;
using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.InputSystem;

public class FPSCameraController : SerializedMonoBehaviour
{
   CinemachineInputAxisController _input;   
    
    public float lookSpeed = 2.0f;

    private void Awake()
    {
        _input = GetComponent<CinemachineInputAxisController>();  //was found at: https://discussions.unity.com/t/how-can-i-change-the-legacy-gain-value-in-a-script-in-cinemachine-input-axis-controller/950807/5
        foreach (var c in _input.Controllers)
        {
            if (c.Name == "Look X (Pan)")
            {
                c.Input.Gain = lookSpeed;
            }
            if (c.Name == "Look Y (Tilt)")
            {
                c.Input.Gain = lookSpeed;
            }
            
        }
            
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
          //was found at: https://discussions.unity.com/t/how-can-i-change-the-legacy-gain-value-in-a-script-in-cinemachine-input-axis-controller/950807/5
        foreach (var c in _input.Controllers)
        {
            if (c.Name == "Look X (Pan)")
            {
                c.Input.Gain = lookSpeed;
            }
            if (c.Name == "Look Y (Tilt)")
            {
                c.Input.Gain = lookSpeed;
            }
            
        }
    }
}
