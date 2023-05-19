using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class enemyBehavior : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;

    [Header("AutoShooter")]
    [SerializeField] private Transform bulletPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float repeatTime = 10.0f;

    [SerializeField] public AudioSource fireSound;

    private void Awake()
    {
        
    }
    private void Start()
    {
        fireSound = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        Move();
        Rotate();
        //Collision? collision = bulletObject.GetComponent<Collision>();
        //if(collision != null)
        //{
        //    Destroy(gameObject);
        //}
        //StartCoroutine(BulletMakeRoutine());
    }
    public void Move()
    {
        Vector3 dir = player.transform.position - transform.position;

        dir.Normalize();
        transform.position += dir * moveSpeed * Time.deltaTime;
    }
    public void Rotate()
    {
        transform.LookAt(player.transform.position);
    }

    private Coroutine bulletRoutine;
    IEnumerator BulletMakeRoutine()
    {
        while (true)
        {
            // 매개변수 (생성 프리펩, 생성 위치, 생성 방향)
            Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
            fireSound.Play();
            // repeatTime마다
            yield return new WaitForSeconds(repeatTime);
        }
    }
}
