using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Video;
using System;
using NUnit.Framework;

public class Wolk : MonoBehaviour
{
    public static Wolk Instance { get;private set; }
    [SerializeField]
    private float speed = 5f;
    private float minMovingSpeed = 0.1f;
    private bool isRunning = false;
    private PlayerInputActions playerInputActions;
     private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();
        Instance = this;
    }

    private Vector2 GetMovementVector()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        return inputVector;
    }
    private void FixedUpdate()
    {
      HandleMovement(); 
    }
    private void HandleMovement()
    {
        Vector2 inputVector = GetMovementVector();
        inputVector =  inputVector.normalized;
        rb.MovePosition(rb.position + inputVector * (speed * Time.fixedDeltaTime));

        if (Mathf.Abs(inputVector.x) > minMovingSpeed || Mathf.Abs(inputVector.y) > minMovingSpeed )
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
    }
    public bool Run()
    {
        return isRunning;
    }
}
