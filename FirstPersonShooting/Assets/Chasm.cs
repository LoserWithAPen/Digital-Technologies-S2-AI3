using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasm : MonoBehaviour
{
    public float falldamage = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            other.GetComponent<PlayerHealth>().PlayerTakeDamage(falldamage);
            other.transform.position = other.GetComponent<PlayerController>().groundpos;
        }
    }
}
