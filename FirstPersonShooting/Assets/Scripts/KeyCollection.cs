using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollection : MonoBehaviour
{
    public int keyValue = 1;

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            GameManager.instance.ChangeKeys(keyValue);
            Destroy(gameObject);
        }
    }
}