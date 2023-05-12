using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float movePower = 2.0f;
    public float jumpPower = 5.0f;
    public float rotateSpeed = 2.0f;
    private Rigidbody rb;
    private Vector3 moveDir;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Move();
        Rotate();
    }
    private void Move() {
        // 바라보고 있는 방향 앞
        transform.Translate(moveDir * movePower * Time.deltaTime);
        //transform.Rotate(Vector3.up ,moveDir.x * rotateSpeed * Time.deltaTime, Space.Self);
    }
    public void Rotate()
    {
        transform.Rotate(Vector3.up ,moveDir.x * rotateSpeed * Time.deltaTime, Space.Self);

    }
    public void LookAt()
    {
        transform.LookAt(new Vector3(0, 0, 0));
    }
    public void Rotation()
    {
        transform.position = new Vector3(0, 0, 0);

        transform.rotation = Quaternion.identity; //0,0,0
        transform.rotation = Quaternion.Euler(0, 90, 0);
        Vector3 rotation = transform.rotation.ToEulerAngles();
    }
    public void Jump()
    {
        rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }
    private void OnMove(InputValue value)
    {
        moveDir.x = value.Get<Vector2>().x;
        moveDir.z = value.Get<Vector2>().y;
    }
    private void OnJump(InputValue value)
    {
        Jump();
        //bool isPress = value.isPressed;
    }

}
