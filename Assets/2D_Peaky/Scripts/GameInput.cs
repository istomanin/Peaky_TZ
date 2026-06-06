using UnityEngine;


public class GameInput : MonoBehaviour
{

    [SerializeField] private FloatingJoystick _joystick;


    private PlayerInput _playerInputActions;


    public static GameInput Instance { get; private set; }



    private void Awake()
    {
        Instance = this;
        _playerInputActions = new PlayerInput();
        _playerInputActions.Enable();
        
    }


    public Vector2 GetMovementVector()
    {
        Vector2 keyboardInput = _playerInputActions.Player.Move.ReadValue<Vector2>();
       
         Vector2 joystickInput =_joystick != null? _joystick.Direction : Vector2.zero;

        bool joystickActive = joystickInput.magnitude > 0.1f;

       return joystickActive ? joystickInput: keyboardInput;

    }
    public void DisableMovement()
    {
        _playerInputActions.Disable();
    }


}