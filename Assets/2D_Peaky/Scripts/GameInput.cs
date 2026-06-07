using System;
using UnityEngine;
using UnityEngine.InputSystem;



public class GameInput : MonoBehaviour
{

    [SerializeField] private FloatingJoystick _joystick;


    private PlayerInput _playerInputActions;


    public static GameInput Instance { get; private set; }

    public event EventHandler OnPlayerPressE;



    private void Awake()
    {
        Instance = this;
        _playerInputActions = new PlayerInput();
        _playerInputActions.Enable();


        _playerInputActions.Player.PressE.performed += PlayerPressE_performed;

    }


    public Vector2 GetMovementVector()
    {
        Vector2 keyboardInput = _playerInputActions.Player.Move.ReadValue<Vector2>();

        Vector2 joystickInput = _joystick != null ? _joystick.Direction : Vector2.zero;

        bool joystickActive = joystickInput.magnitude > 0.1f;

        return joystickActive ? joystickInput : keyboardInput;

    }
    public void DisableMovement()
    {
        _playerInputActions.Disable();
    }



    private void PlayerPressE_performed(InputAction.CallbackContext context)
    {
        OnPlayerPressE?.Invoke(this, EventArgs.Empty);
    }


}