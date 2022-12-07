using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const string moveAxisX = "Horizontal";
    private const string moveAxisZ = "Vertical";

    public Vector3 moveInput
    {
        get
        {
            return new Vector3(Input.GetAxisRaw(moveAxisX), 0, Input.GetAxisRaw(moveAxisZ));
        }
    }

    private bool isAttack => Input.GetMouseButtonDown(0);

}
