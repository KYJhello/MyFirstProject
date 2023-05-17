using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityCollision : MonoBehaviour
{
    // 충돌 진입했을 때
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision Start");
    }
    // 계속 충돌중
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("collsion ing");
    }
    // 충돌이 사라졌을 때
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("collision exit");
    }

    //트리거

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger Enter");
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("trigger ing");
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("trigger exit");
    }
}
