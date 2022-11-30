using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform Target;
    [SerializeField] private Transform Player;

    private float mouseX;
    private float mouseY;

    void Update()
    {
        RotateToMousePos();
    }

    private void RotateToMousePos()
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
    }
}
