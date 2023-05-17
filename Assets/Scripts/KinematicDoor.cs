using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������Ʈ�� �����ϴ� ������Ʈ�� ��� ���� ������
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

    }// ��� �浹��
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("collsion ing");
    }
    // �浹�� ������� ��
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("collision exit");
    }
}
