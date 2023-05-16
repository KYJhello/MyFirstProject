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

    // 플레이어의 입력으로 총알생성 구현
    [Header("Shooter")]
    [SerializeField] private Transform bulletPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float repeatTime = 0.1f;


    // 카메라
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    //음향
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

    // 2. 플레이어의 Fire(좌클릭)입력으로 총알생성 구현
    public void OnFire(InputValue value)
    { 
        Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
    }

    // 3. 코루틴을 이용하여 누르고 있는 동안 연사 구현
    private Coroutine bulletRoutine;
    IEnumerator BulletMakeRoutine()
    {
        fireSound = gameObject.GetComponent<AudioSource>();
        while (true)
        {
            // 매개변수 (생성 프리펩, 생성 위치, 생성 방향)
            Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
            fireSound.Play();
            // repeatTime마다
            yield return new WaitForSeconds(repeatTime);
        }
    }
    // RepeatFire(좌ctrl)버튼이 눌리고 있는동안 연사되도록 구현
    private void OnRepeatFire(InputValue value)
    {
        if (value.isPressed)
        {
            Debug.Log("누를떄");
            bulletRoutine = StartCoroutine(BulletMakeRoutine());
        }
        else
        {
            StopCoroutine(bulletRoutine);
            Debug.Log("땠을떄");
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
