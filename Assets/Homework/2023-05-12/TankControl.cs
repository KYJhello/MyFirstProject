using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankControl : MonoBehaviour
{
    public float moveForce = 5.0f;
    public float jumpForce = 1.5f;
    public float rotateForce = 90.0f;
    private Vector3 moveDir;

    private void Update()
    {
        Move();
        Rotate();
        //Rotation();
    }
    public void Move()
    {
        //transform.position += moveForce * moveDir * Time.deltaTime;
        transform.Translate(moveDir * moveForce * Time.deltaTime, Space.Self);
    }
    public void Rotate()
    {
        //transform.LookAt(moveDir);
        transform.Rotate(Vector3.up * moveDir.x * rotateForce * Time.deltaTime, Space.Self);
    }
    //public void LookAt()
    //{
    //    transform.LookAt(new Vector3(0, 0, 0));
    //}
    private void OnMove(InputValue value)
    {
        moveDir.x = value.Get<Vector2>().x;
        moveDir.y = 0.0f;
        moveDir.z = value.Get<Vector2>().y;
    }
    public void Rotation()
    {
        transform.rotation = Quaternion.identity;
        transform.rotation = Quaternion.Euler(moveDir.x, 0, moveDir.z);
        //transform.rotation.ToEulerAngles();
    }
    private void OnJump(InputValue value)
    {
        Jump();
    }
    public void Jump()
    {
        transform.Translate(Vector3.up * Time.deltaTime * jumpForce);
        
    }


}
