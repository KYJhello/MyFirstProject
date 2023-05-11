using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 4. ��ũ��Ʈ ����ȭ ����� �̿��Ͽ�
    // 3������ ������ ������ ������ ������ �� �ֵ��� ����

    [SerializeField]
    public float Speed = 10.0f;
    public float rotateSpeed = 10.0f;
    public float jumpForce = 1.0f;


    Rigidbody body;
    float h, v;


    // 2. ��ũ��Ʈ �޽��� �̺�Ʈ �Լ��� �̿��Ͽ�
    // ������ �������ڸ��� �̸��� "Player"�� �ٲٴ�
    // ������Ʈ ����

    private void Awake()
    {
        this.name = "Player";
    }

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        // 3. ��ũ��Ʈ�� �̿��Ͽ� ������ �������ڸ���
        // ���� �����ϴ� ������Ʈ ����
        // ������ٵ� ������Ʈ��
        //  AddForce(Vector3.up * 5, ForceMode.Impulse)
        body.AddForce(Vector3.up * 5, ForceMode.Impulse);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FixedUpdate()
    {
        Move();
        Jump();
    }
    void Move()
    {

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);

        if (!(h == 0 && v == 0))
        {
            transform.position += dir * Speed * Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * rotateSpeed);
        }
    }
    void Jump()
    {
        // �����̽��ٸ� ������(�Ǵ� ������ ������)
        if (Input.GetKey(KeyCode.Space))
        {
            // body�� ���� ���Ѵ�(AddForce)
            // AddForce(����, ���� ��� ���� ���ΰ�)
            body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
