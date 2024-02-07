using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    public static PlayerInput PlayerInput;
    
    public static Vector2 MoveInput;

    public static bool WasAttckPressed;
    public static bool WasDashPressed;
    public static bool WasInteractPressed;
    
    private InputAction _moveAction;
    private InputAction _attackAction;
    private InputAction _dashAction;
    private InputAction _interactAction;
    
    private void Awake()
    {
        _moveAction = PlayerInput.actions["Movement"];
        _attackAction = PlayerInput.actions["Attack"];
        _dashAction = PlayerInput.actions["Dash"];
        _interactAction = PlayerInput.actions["Interact"];
    }

    // Update is called once per frame
    private void Update()
    {
        MoveInput = _moveAction.ReadValue<Vector2>();

        WasAttckPressed = _attackAction.WasPressedThisFrame();
        WasDashPressed = _dashAction.WasPressedThisFrame();
        WasInteractPressed = _interactAction.WasPressedThisFrame();
    }
}
