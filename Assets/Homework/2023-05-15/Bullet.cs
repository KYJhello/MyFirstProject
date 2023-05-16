using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 컴포넌트에 의존하는 컴포넌트의 경우 오류 방지용
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
        // 1. 생성시 앞으로 날아가기 구현
        rb.velocity = transform.forward * bulletSpeed;
        Destroy(gameObject, 5f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("충돌 발생 객체 소멸");
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);

    }
}
