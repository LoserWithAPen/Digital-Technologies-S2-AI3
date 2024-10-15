using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Target : MonoBehaviour
{
    //information injection
    public SpawnPointData spawn;
    public Vector3 target;
    [HideInInspector] public bool pTarget;

    public float maxhealth = 50f;
    [HideInInspector] public float health;
    public GameObject collectable;
    Random drop = new Random();

    private void Awake()
    {
        health = maxhealth;
    }
    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0f)
        {
            if (drop.Next(2) == 0)
            {
                Instantiate(collectable, gameObject.transform.position, Quaternion.identity);
            }
            Die();
        }
    }
    void Die()
    {
        if (spawn != null)
        {
            spawn.alive = false;
        }
        Destroy(gameObject);
    }
}
