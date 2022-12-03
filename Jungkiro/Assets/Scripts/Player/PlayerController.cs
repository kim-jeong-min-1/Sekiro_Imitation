using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;

    private PlayerInput playerInput;
    private Rigidbody rb;
    private CameraHandler playerCamera;

    private Vector3 rotateDirection;
    private float turnSmoothTime = 5.5f;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerCamera = GameObject.Find("Camera Holder").GetComponent<CameraHandler>();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        PlayerMovement(playerInput.moveInput);
        PlayerRotate(rotateDirection);
    }

    private void PlayerMovement(Vector3 moveInput)
    {
        var targetDirection = playerCamera.transform;
        var moveDirection = targetDirection.forward * moveInput.z + targetDirection.right * moveInput.x;
        moveDirection.y = 0;

        rotateDirection = moveDirection;
        moveDirection = moveDirection.normalized;

        var velocity = moveDirection * playerStats.moveSpeed + Vector3.up * rb.velocity.y;
        rb.velocity = velocity;
    }

    private void PlayerRotate(Vector3 direction)
    {
        Vector3 targetDir = direction;
        targetDir.y = 0;

        if (targetDir == Vector3.zero) targetDir = transform.forward;

        Quaternion rotationValue = Quaternion.LookRotation(targetDir);
        Quaternion targetRotation = Quaternion.Slerp(transform.rotation, rotationValue, Time.deltaTime * turnSmoothTime);

        transform.rotation = targetRotation;
    }
}
