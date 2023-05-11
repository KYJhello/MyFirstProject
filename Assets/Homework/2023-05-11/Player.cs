using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 4. 스크립트 직렬화 기능을 이용하여
    // 3번에서 구현한 점프의 강도를 조절할 수 있도록 수정

    [SerializeField]
    public float Speed = 10.0f;
    public float rotateSpeed = 10.0f;
    public float jumpForce = 1.0f;


    Rigidbody body;
    float h, v;


    // 2. 스크립트 메시지 이벤트 함수를 이용하여
    // 게임이 시작하자마자 이름이 "Player"로 바꾸는
    // 컴포넌트 구현

    private void Awake()
    {
        this.name = "Player";
    }

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        // 3. 스크립트를 이용하여 게임이 시작하자마자
        // 위로 점프하는 컴포넌트 구현
        // 리지드바디 컴포넌트에
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
        // 스페이스바를 누르면(또는 누르고 있으면)
        if (Input.GetKey(KeyCode.Space))
        {
            // body에 힘을 가한다(AddForce)
            // AddForce(방향, 힘을 어떻게 가할 것인가)
            body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
