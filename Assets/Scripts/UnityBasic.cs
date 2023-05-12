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
        // 컴포넌트가 붙어있는 게임오브젝트는
        // gameObject 속성을 이용하여 접근가능

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

        
        FindObjectOfType<AudioSource>(); // 씬 내의 컴포넌트 탐색
        

    }
}
