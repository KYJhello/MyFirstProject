using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    [Header("Mover")]
    [SerializeField]
    private float movePower;
    [SerializeField]
    private float maxMove;
    [SerializeField]
    private float rotatePower;
    [SerializeField]
    private float maxRotate;

    [SerializeField]
    private new Rigidbody rigidbody;

    private Vector3 moveDir;

    private void Update()
    {
        UpdateMove();
        UpdateRotate();
    }
    private void OnMove(InputValue value)
    {
        moveDir.x = value.Get<Vector2>().x;
        moveDir.y = 0.0f;
        moveDir.z = value.Get<Vector2>().y;
    }
    private void UpdateMove()
    {
        transform.Translate(moveDir * movePower * Time.deltaTime, Space.Self);
    }

    private void UpdateRotate()
    {
        transform.Rotate(Vector3.up * moveDir.x * rotatePower * Time.deltaTime, Space.Self);
    }

    public void Move(Vector3 moveDir)
    {
        this.moveDir = moveDir;
    }
}
