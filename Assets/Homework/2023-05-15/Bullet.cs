using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������Ʈ�� �����ϴ� ������Ʈ�� ��� ���� ������
[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private GameObject explosionEffect;

    [SerializeField] private AudioSource explosionSource;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        explosionSource = gameObject.GetComponent<AudioSource>();
        // 1. ������ ������ ���ư��� ����
        rb.velocity = transform.forward * bulletSpeed;
        Destroy(gameObject, 5f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("�浹 �߻� ��ü �Ҹ�");
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);

    }
}
