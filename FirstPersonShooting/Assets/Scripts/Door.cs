using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Door : MonoBehaviour
{
    public DoorCollider dc;
    Vector3 targetDown;
    Vector3 targetUp;

    private void Awake()
    {
        targetDown = transform.position + new Vector3(0,-4f,0);
        targetUp = transform.position;
    }
    void Update()
    {
        if (dc.isUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetUp, dc.speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, targetDown, dc.speed * Time.deltaTime);
        }
    }
}
