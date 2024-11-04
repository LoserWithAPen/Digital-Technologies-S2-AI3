using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firebreath : MonoBehaviour
{
    // Start is called before the first frame update
    /*Transform Player;
    public int damage = 10;
    public int scoreValue = -1;

    public ParticleSystem FireBreath;


    private void Awake()
    {
        Player = GameObject.Find("Player").transform;
        FireBreath = GetComponent<ParticleSystem>();
    }*/
    Transform Player;
    int scoreValue = -1;
    int damage = 10;
    public ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents;

    void Start()
    {
   
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }
    private void Awake()
    {
        Player = GameObject.Find("Player").transform;
    }

    void OnParticleCollision(GameObject other)
    {

        Debug.Log("Found Collision");
        //int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);
        //int i = 0;

        //while (i < numCollisionEvents)
        //{
            if (other.transform.name == "Player")
            {
                Debug.Log("Found Player");
            PlayerHealth attacked = Player.GetComponent<PlayerHealth>();
            GameManager.instance.ChangeScore(scoreValue);
            attacked.PlayerTakeDamage(damage);
        }
        //}


    }
}