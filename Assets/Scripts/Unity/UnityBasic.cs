using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityBasic : MonoBehaviour
{
    GameObject player;
    public AudioSource audioSource;
    //public GameObject thisGameObject;
    public void Start()
    {
        GameObjectBasic();
        ComponentBasic();
    }
    public void GameObjectBasic()
    {
        // ������Ʈ�� �پ��ִ� ���ӿ�����Ʈ��
        // gameObject �Ӽ��� �̿��Ͽ� ���ٰ���

        //thisGameObject = gameObject;
        //gameObject.name = "player";
        GameObject obj = GameObject.Find("Player");
        GameObject.FindGameObjectWithTag("Player");
        GameObject.FindGameObjectsWithTag("Player");

        GameObject newObject = new GameObject();
        newObject.name = "New Game Object";

        Destroy(gameObject,5f);
    }
    //public Rigidbody rb;
    public void ComponentBasic()
    {

        audioSource = GetComponent<AudioSource>();
        audioSource = gameObject.GetComponent<AudioSource>();
        GetComponents<AudioSource>();
        gameObject.GetComponents<AudioSource>();

        GetComponentsInChildren<Rigidbody>();

        
        FindObjectOfType<AudioSource>(); // �� ���� ������Ʈ Ž��
        

    }
}
