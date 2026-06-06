using System;
using System.Collections;
using UnityEngine;

[SelectionBase]
public class Player : MonoBehaviour
{
    public static Player Instance;
    
  

    [SerializeField] private float movingSpeed = 5f;
   
    private Rigidbody2D _rb;
  

    private Vector2 _inputVector;
  

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
      
        Instance = this;
       
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

        _rb.MovePosition(_rb.position + _inputVector * (movingSpeed * Time.fixedDeltaTime));

    }
}
