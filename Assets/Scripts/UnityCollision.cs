using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityCollision : MonoBehaviour
{
    // �浹 �������� ��
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision Start");
    }
    // ��� �浹��
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("collsion ing");
    }
    // �浹�� ������� ��
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("collision exit");
    }

    //Ʈ����

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
