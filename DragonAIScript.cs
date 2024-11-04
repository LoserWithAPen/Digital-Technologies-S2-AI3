using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class DragonAIScript : MonoBehaviour
{
    Transform Player;
    NavMeshAgent agent;
    public int damage = 10;

    Transform DragonAttack;
    Transform DragonAttackRanged;
    Transform enemy;
    public float distanceToEnemy = 1.5f;
    public float distanceToEnemy2 = 1.5f;
    public int scoreValue = -1;
    public bool canAttack = true;
    public GameObject fireballPrefab;
    public float bulletSpeed = 25f;
    float nextToPlayer;
    float closeToPlayer;
    float farFromPlayer;
    public float speed = 1.5f;
    public float turnRate;

    ParticleSystem FireBreath;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 3f;
        agent.stoppingDistance = 2.5f;
        enemy = gameObject.transform;
        DragonAttackRanged = GameObject.Find("Mouth").transform;
        DragonAttack = GameObject.Find("Point of Attack").transform;
        fireballPrefab = Resources.Load("prefabs/fireBall") as GameObject;
        Player = GameObject.Find("Player").transform;
        FireBreath = GetComponentInChildren<ParticleSystem>();

    }

    void Update()
    {
        //FireBreath.Stop();
        transform.LookAt(Player);
        Vector3.RotateTowards(enemy.position, Player.position, 50, 50);
        agent.SetDestination(Player.position);
        if (canAttack == true)
        {
            if (isNextToPlayer())
            {
                Debug.Log("Melee done");
                PlayerHealth attacked = Player.GetComponent<PlayerHealth>();
                GameManager.instance.ChangeScore(scoreValue);
                attacked.PlayerTakeDamage(damage);
                canAttack = false;
                Invoke("ResetAttack", 2f);
            }
            else if (isCloseToPlayer())
            {
                Debug.Log("Firebreath Activated");
                agent.isStopped = true;
                Invoke("AgentStart", 5f);
                FireBreath.Play();
                Invoke("killFire", 5f);
                canAttack = false;
                Invoke("ResetAttack", 7f);
            }
            else if (isFarFromPlayer())
            {
                Invoke("AgentStart", 5f);
                agent.isStopped = true;
                Vector3 towardsPlayer = Player.transform.position - DragonAttackRanged.transform.position;
                Debug.Log(towardsPlayer);
                var fireball = Instantiate(fireballPrefab, DragonAttackRanged.position, DragonAttackRanged.rotation); ;
                fireball.GetComponent<Rigidbody>().velocity = towardsPlayer.normalized * bulletSpeed;
                Debug.Log("One Fireball made");
                canAttack = false;
                Invoke("ResetAttack", 3f);

            }
            else
            {
                canAttack = false;
                Invoke("ResetAttack", 2f);
            }
        }
        canAttack = false;
    }

    //agent.isStopped = false;
    
    void killFire()
{
    FireBreath.Stop();
}
void AgentStart()
{
    agent.isStopped = false;
}
void ResetAttack()
{
    canAttack = true;
}

private bool isNextToPlayer()
{
    RaycastHit hit;
    Vector3 p1 = transform.position;

    // Cast a sphere wrapping character controller 10 meters forward
    // to see if it is about to hit anything.
    if (Physics.SphereCast(p1, distanceToEnemy, transform.forward, out hit, 2))
    {
        //Debug.Log(hit.transform.name);
        GameObject go = GameObject.Find(hit.transform.name);

        if (go.name == "Player")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    else
    {
        return false;
    }
    //return Physics.CheckSphere(Player.position, distanceToEnemy, enemyMask);
}

private bool isCloseToPlayer()
{
    RaycastHit hit;
    Vector3 p1 = transform.position;

    // Cast a sphere wrapping character controller 10 meters forward
    // to see if it is about to hit anything.
    if (Physics.SphereCast(p1, distanceToEnemy, transform.forward, out hit, 25))
    {
        //Debug.Log(hit.transform.name);
        GameObject go = GameObject.Find(hit.transform.name);

        if (go.name == "Player")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    else
    {
        return false;
    }
    //return Physics.CheckSphere(Player.position, distanceToEnemy, enemyMask);
}
private bool isFarFromPlayer()
{
    RaycastHit hit;
    Vector3 p1 = transform.position;

    // Cast a sphere wrapping character controller 10 meters forward
    // to see if it is about to hit anything.
    if (Physics.SphereCast(p1, distanceToEnemy, transform.forward, out hit, 50))
    {
        //Debug.Log(hit.transform.name);
        GameObject go = GameObject.Find(hit.transform.name);

        if (go.name == "Player")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    else
    {
        return false;
    }
    //return Physics.CheckSphere(Player.position, distanceToEnemy, enemyMask);
}
}