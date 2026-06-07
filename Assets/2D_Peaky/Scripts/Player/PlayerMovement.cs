using System.Collections;
using UnityEngine;

[SelectionBase]
public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float MapLimit = 12.5f;
   
    [SerializeField] private float movingSpeed = 5f;


    private float _defaultMovingSpeed;
    private Rigidbody2D _rb;


    private Vector2 _inputVector;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _defaultMovingSpeed = movingSpeed;
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

    public void ApplySpeedBoost(float bonusSpeedValue)
    {
       StartCoroutine(SpeedBoostCoroutine(bonusSpeedValue));  

    }

    private IEnumerator SpeedBoostCoroutine(float bonusSpeedValue)
    {
        Debug.Log("Speed Boost Activated!");
        movingSpeed *= bonusSpeedValue;

        yield return new WaitForSeconds(4f);

        ResetSpeed();
    }


    private void ResetSpeed()
    {
        movingSpeed = _defaultMovingSpeed;
        Debug.Log("Speed Boost Ended. Speed Reset.");
    }

}
