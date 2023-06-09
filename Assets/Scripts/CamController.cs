using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public GameObject player;
    private float h;
    private float v;
    public float Speed = 10.0f;
    public float rotateSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h,0, v);
        Vector3 dir2 = new Vector3(0, 2.0f, 2.0f);

        if (!(h ==0 && v == 0)){
            transform.position += player.transform.position - transform.position;

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * rotateSpeed);
            if(transform.rotation.z < 0) { transform.position += dir2; }
            else { transform.position -= dir2; }
        }
        
    }
}
