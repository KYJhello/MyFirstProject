using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankControl : MonoBehaviour
{
    [SerializeField]
    public float moveForce = 5.0f;
    public float jumpForce = 1.5f;
    public float rotateForce = 90.0f;
    private Vector3 moveDir;

    // �÷��̾��� �Է����� �Ѿ˻��� ����
    [Header("Shooter")]
    [SerializeField] private Transform bulletPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float repeatTime = 0.1f;


    // ī�޶�
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    //����
    [SerializeField] public AudioSource fireSound;


    private void Update()
    {
        Move();
        Rotate();
        //Rotation();
    }
    public void Move()
    {
        //transform.position += moveForce * moveDir * Time.deltaTime;
        transform.Translate(moveDir * moveForce * Time.deltaTime, Space.Self);
    }
    public void Rotate()
    {
        //transform.LookAt(moveDir);
        transform.Rotate(Vector3.up * moveDir.x * rotateForce * Time.deltaTime, Space.Self);
    }
    //public void LookAt()
    //{
    //    transform.LookAt(new Vector3(0, 0, 0));
    //}
    private void OnMove(InputValue value)
    {
        moveDir.x = value.Get<Vector2>().x;
        moveDir.y = 0.0f;
        moveDir.z = value.Get<Vector2>().y;
    }
    public void Rotation()
    {
        transform.rotation = Quaternion.identity;
        transform.rotation = Quaternion.Euler(moveDir.x, 0, moveDir.z);
        //transform.rotation.ToEulerAngles();
    }

    // 2. �÷��̾��� Fire(��Ŭ��)�Է����� �Ѿ˻��� ����
    public void OnFire(InputValue value)
    { 
        Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
    }

    // 3. �ڷ�ƾ�� �̿��Ͽ� ������ �ִ� ���� ���� ����
    private Coroutine bulletRoutine;
    IEnumerator BulletMakeRoutine()
    {
        fireSound = gameObject.GetComponent<AudioSource>();
        while (true)
        {
            // �Ű����� (���� ������, ���� ��ġ, ���� ����)
            Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
            fireSound.Play();
            // repeatTime����
            yield return new WaitForSeconds(repeatTime);
        }
    }
    // RepeatFire(��ctrl)��ư�� ������ �ִµ��� ����ǵ��� ����
    private void OnRepeatFire(InputValue value)
    {
        if (value.isPressed)
        {
            Debug.Log("������");
            bulletRoutine = StartCoroutine(BulletMakeRoutine());
        }
        else
        {
            StopCoroutine(bulletRoutine);
            Debug.Log("������");
        }
    }
    private void OnZoom(InputValue value)
    {
        if (value.isPressed)
        {
            virtualCamera.Priority = 1;
        }
        else
        {
            virtualCamera.Priority = 50;
        }
    }
}
