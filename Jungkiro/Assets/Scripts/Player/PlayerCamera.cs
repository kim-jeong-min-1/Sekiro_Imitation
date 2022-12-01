using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform target;
    [SerializeField] private Transform player;

    private float mouseX;
    private float mouseY;

    private void Start()
    {
        //Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        RotateToMousePos();
    }

    private void RotateToMousePos()
    {
        mouseY += -Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -30, 60);

        LookAtToTarget();

        target.rotation = Quaternion.Euler(mouseY, mouseX, 0f);
        //player.rotation = Quaternion.Euler(0f, mouseX, 0f);
    }

    private void LookAtToTarget()
    {
        Vector3 angle = (target.transform.position - transform.position).normalized;
        transform.forward = angle;
    }
}
