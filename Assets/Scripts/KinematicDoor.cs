using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 컴포넌트에 의존하는 컴포넌트의 경우 오류 방지용
[RequireComponent(typeof(Rigidbody))]
public class KinematicDoor : MonoBehaviour
{
    [SerializeField] private float OpenSpeed = 10f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision Start");
        while (true)
        {
            new WaitForFixedUpdate();
            transform.Translate(Vector3.left * OpenSpeed * Time.deltaTime);
            OpenSpeed--;
            if (OpenSpeed < 0) {
                
                while (true) {
                    OpenSpeed++;
                    transform.Translate(Vector3.right * OpenSpeed * Time.deltaTime);
                    if (OpenSpeed > 10f) { break; }
                }
                
                break; 
            }
        }

    }// 계속 충돌중
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("collsion ing");
    }
    // 충돌이 사라졌을 때
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("collision exit");
    }
}
