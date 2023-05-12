using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControl : MonoBehaviour
{
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
    public void Move()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);

        transform.Translate(dir * moveForce * Time.deltaTime);
        transform.Rotate(Vector3.up, Time.deltaTime, Space.Self);
    }
    public void Jump()
    {
        if (Input.GetButton("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }


}
