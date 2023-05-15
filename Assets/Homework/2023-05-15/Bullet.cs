using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������Ʈ�� �����ϴ� ������Ʈ�� ��� ���� ������
[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 10f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        // 1. ������ ������ ���ư��� ����
        rb.velocity = transform.forward * bulletSpeed;
        Destroy(gameObject, 5f);
    }
}
