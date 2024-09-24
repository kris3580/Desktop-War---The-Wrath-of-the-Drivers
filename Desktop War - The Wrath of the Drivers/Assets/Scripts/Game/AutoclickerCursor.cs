using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoclickerCursor : MonoBehaviour
{

    public Vector3 moveDirection;
    public float speed;

    void Update()
    {
        transform.position += moveDirection * Time.deltaTime * speed;
        Debug.Log(moveDirection);
    }
}
