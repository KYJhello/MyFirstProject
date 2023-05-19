using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerShooter : MonoBehaviour
{
    [Header("Shooter")]
    [SerializeField]
    private CinemachineVirtualCamera focuseCam;
    [SerializeField]
    private Bullet bulletPrefab;
    [SerializeField]
    private float bulletRepeatTime;
    private float bulletCoolTime;

    public UnityEvent OnFire;
    [SerializeField] private AudioSource fireSound;


    public void Fire(InputValue value)
    {
        Shoot();
    }
    
    public void Shoot()
    {
        if (bulletCoolTime <= 0)
        {
            fireSound.Play();
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            StartCoroutine(BulletCoolTimeRoutine());

            // 싱글톤을 이용한 전역접근
            GameManager.Data.AddShootCount(1);
            OnFire?.Invoke();
        }
    }

    public void Focus(bool focus)
    {
        focuseCam.Priority = focus ? 999 : 0;
    }

    IEnumerator BulletCoolTimeRoutine()
    {
        bulletCoolTime = bulletRepeatTime;
        float reapeatTime = 0.1f;
        while (true)
        {
            yield return new WaitForSeconds(reapeatTime);
            bulletCoolTime -= reapeatTime;

            if (bulletCoolTime <= 0)
            {
                bulletCoolTime = 0;
                break;
            }
        }
    }
}
