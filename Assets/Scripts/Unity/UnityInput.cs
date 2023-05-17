using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class UnityInput : MonoBehaviour
{
    [SerializeField]
    private void Update()
    {
        InputByDevice();
        InputByInputManager();
    }

    private void InputByDevice()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Key UP");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Key Down");
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Key pressing");
        }

        if (Input.GetMouseButton(0))
        {
            Debug.Log("Mouse Left button pressing");
        }
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Mouse Left button Up");
        }
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse Left button Down");
        }
    }
    private void InputByInputManager()
    {
        if (Input.GetButton("Jump"))
        {
            Debug.Log("Fire1 is pressing");
        }
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");


    }
    private void OnMove(InputValue value)
    {
        Vector2 dir = value.Get<Vector2>();
    }
    private void OnJump(InputValue value)
    {
        bool isPress = value.isPressed;
    }

}
