using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Vector3 _direction;
    private Joystick _joystick;

    private void Start()
    {
        _joystick = Joystick.Instance;
    }

    void FixedUpdate()
    {
        _direction = _joystick.Direction;
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }

    void Jump()
    {
        
    }
}
