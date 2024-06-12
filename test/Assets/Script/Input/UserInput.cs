using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UserInput : MonoBehaviour
{
    public static PlayerInput _playerInput;
    public static Vector2 Movement;

    //public static bool WasAttckPressed;
    public static bool WasShiftPressed;
    public static bool WasInteractPressed;
    
    private InputAction _moveAction;
    //private InputAction _attackAction;
    private InputAction _shiftAction;
    private InputAction _interactAction;
    
    public void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _moveAction = _playerInput.actions["Move"];
        //_attackAction = _playerInput.actions["Attack"];
        _shiftAction = _playerInput.actions["Shift"];
        _interactAction = _playerInput.actions["Interact"];
    }

    // Update is called once per frame
    private void Update()
    {
        Movement = _moveAction.ReadValue<Vector2>();

        //WasAttckPressed = _attackAction.WasPressedThisFrame();
        WasShiftPressed = _shiftAction.IsPressed();
        WasInteractPressed = _interactAction.WasPressedThisFrame();
    }
}
