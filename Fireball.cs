using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    Transform Player;
    int scoreValue = -1;
    int damage = 10;
    int distanceToEnemy = 0;
    private void Start()
    {
        Invoke("killBullet", 10f);
    }
    void Awake()
    {
        Player = GameObject.Find("Player").transform;

    }

    void OnTriggerEnter(Collider other)
    {
        //Destroy(collision.gameObject);
        //Destroy(gameObject);
        GameObject go = GameObject.Find(other.transform.name);
        if (go.transform.name == "Player")
        {
            killBullet();
            PlayerHealth attacked = Player.GetComponent<PlayerHealth>();
            GameManager.instance.ChangeScore(scoreValue);
            attacked.PlayerTakeDamage(damage);
        }

    }
    void killBullet()
    {
        Destroy(gameObject);
    }
}