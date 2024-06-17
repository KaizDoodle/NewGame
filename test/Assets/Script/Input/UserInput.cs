using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UserInput : MonoBehaviour
{
    public static PlayerInput _playerInput;
    public static Vector2 Movement;

    public static bool WasAttackPressed;
    public static bool WasShiftPressed;
    public static bool WasInteractPressed;
    
    private InputAction _moveAction;
    private InputAction _attackAction;
    private InputAction _shiftAction;
    private InputAction _interactAction;

    private float attackTimeCounter;
    
    public void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _moveAction = _playerInput.actions["Move"];
        _attackAction = _playerInput.actions["Attack"];
        _shiftAction = _playerInput.actions["Shift"];
        _interactAction = _playerInput.actions["Interact"];
    }

    // Update is called once per frame
    private void Update()
    {

        if (UserInput.WasAttackPressed && attackTimeCounter > 1.5f){
            attackTimeCounter = 0f;
        }
        
        attackTimeCounter += Time.deltaTime;
        
        //cant move while attacking 
        if (attackTimeCounter > 0.2f){
            Movement = _moveAction.ReadValue<Vector2>();
        } else {
                Movement.Set(0f, 0f);
        }
        WasAttackPressed = _attackAction.WasPressedThisFrame();
        WasShiftPressed = _shiftAction.IsPressed();
        WasInteractPressed = _interactAction.WasPressedThisFrame();
    }
}
