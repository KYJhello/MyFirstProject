using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class enemyBehavior : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;

    [Header("AutoShooter")]
    [SerializeField] private Transform bulletPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float repeatTime = 3.0f;

    private void Update()
    {
        Move();
        Rotate();
        AutoShoot();
    }
    public void Move()
    {
        
    }
    public void Rotate()
    {

    }
    public void AutoShoot()
    {

    }

}
