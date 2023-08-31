using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector3 MoveDirection = Vector3.zero;
    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        if(input != null)
        {
            MoveDirection = new Vector3(input.x, 0f, input.y);
            Debug.Log(MoveDirection);
        }

        
    }

    private void Update()
    {
        transform.position += MoveDirection * Time.deltaTime;
    }
}
