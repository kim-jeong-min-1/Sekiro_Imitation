using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInput playerInput;
    private Rigidbody rb;
    
    [SerializeField] private PlayerStats playerStats;

    [SerializeField] private float turnSmoothVelocity;
    [SerializeField] private float turnSmoothTime = 0.1f;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        PlayerMovement(playerInput.moveInput);
        PlayerRotate();
    }

    private void PlayerMovement(Vector3 moveInput)
    {
        var moveDirection = (transform.forward * moveInput.z + transform.right * moveInput.x).normalized;
        var velocity = moveDirection * playerStats.moveSpeed + Vector3.up * rb.velocity.y;

        rb.velocity = velocity;
    }

    private void PlayerRotate()
    {
        var targetRotation = rb.velocity.normalized;
        var rotationValue = Mathf.SmoothDamp(transform.eulerAngles.y, targetRotation.magnitude, ref turnSmoothVelocity, turnSmoothTime);

        transform.eulerAngles = Vector3.up * rotationValue;
    }
}
