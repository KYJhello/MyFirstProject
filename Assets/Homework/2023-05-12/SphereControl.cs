using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereControl : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;
    public float moveForce;
    public float jumpForce;
    public float rotateForce;
    public float h;
    public float v;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        moveForce = 1.5f;
        jumpForce = 1.5f;
        rotateForce = 1.5f;
    }
    public void FixedUpdate()
    {
        Move();
        Jump();
    }
    public void Move() {
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            rb.AddForce(Vector3.left * moveForce);
        }

        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            rb.AddForce(Vector3.right * moveForce);
        }

        if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            rb.AddForce(Vector3.forward * moveForce);
        }

        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            rb.AddForce(Vector3.back * moveForce);
        }
    }
    public void Jump() {
        if (Input.GetButton("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

}
