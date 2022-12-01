using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerCamera playerCamera;
    private Rigidbody rb;

    [SerializeField] private float turnSmoothTime = 0.1f;
    [SerializeField] private PlayerStats playerStats;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerCamera = transform.GetChild(0).GetComponentInChildren<PlayerCamera>();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        PlayerMovement(playerInput.moveInput);
        PlayerRotate();
    }

    private void PlayerMovement(Vector3 moveInput)
    {
        var velocity = moveInput * playerStats.moveSpeed + Vector3.up * rb.velocity.y;

        rb.velocity = velocity;
    }

    private void PlayerRotate()
    {
        Vector3 targetDir = playerInput.moveInput;
        targetDir.y = 0;

        if(targetDir == Vector3.zero) targetDir = transform.forward;

        Quaternion rotationValue = Quaternion.LookRotation(targetDir);
        Quaternion targetRotation = Quaternion.Slerp(transform.rotation, rotationValue, Time.deltaTime * turnSmoothTime);

        transform.rotation = targetRotation;
    }
}
