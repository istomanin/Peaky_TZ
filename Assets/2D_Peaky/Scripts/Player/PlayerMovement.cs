using UnityEngine;

[SelectionBase]
public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float MapLimit = 12.5f;
   
    [SerializeField] private float movingSpeed = 5f;

    private Rigidbody2D _rb;


    private Vector2 _inputVector;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

    }


    private void Update()
    {
        _inputVector = GameInput.Instance.GetMovementVector();
    }

    private void FixedUpdate()
    {
        HandleMovment();

    }


    private void HandleMovment()
    {
         Vector2 targetPosition =_rb.position +_inputVector *(movingSpeed * Time.fixedDeltaTime);

        targetPosition.x = Mathf.Clamp(targetPosition.x, -MapLimit, MapLimit);

        targetPosition.y = Mathf.Clamp(targetPosition.y, -MapLimit, MapLimit);

        _rb.MovePosition(targetPosition);

    }


}
