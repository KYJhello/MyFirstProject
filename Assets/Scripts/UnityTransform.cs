using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityTransform : MonoBehaviour
{

    private void Start()
    {
        TranslateMove();
    }

    private void TranslateMove()
    {
        transform.position = new Vector3(10, 10, 10);
        transform.localScale = new Vector3(3, 3, 3);
    }

}
