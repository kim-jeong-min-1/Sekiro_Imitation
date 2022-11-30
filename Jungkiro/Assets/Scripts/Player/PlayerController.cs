using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInput playerInput;
    private Rigidbody rb;
    
    [SerializeField]
    private PlayerStats playerStats;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        rb.velocity = playerInput.moveInput * playerStats.moveSpeed + Vector3.up * rb.velocity.y;
    }
}
