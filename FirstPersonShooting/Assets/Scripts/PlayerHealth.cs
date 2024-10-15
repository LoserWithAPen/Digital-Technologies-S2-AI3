using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth = 100;
    [HideInInspector] public int originalPlayerHealth;
    Random rand = new Random();
    [HideInInspector] public CharacterController Player;
    [HideInInspector] public bool dmgInv = false;
    [SerializeField] int invTime;
    Vector3 startPos;

    private void Awake()
    {
        originalPlayerHealth = playerHealth;
        startPos = transform.position;
        Player = gameObject.GetComponent("CharacterController") as CharacterController;
    }

    private void Update()
    {
        if (playerHealth <= 0)
        {
            playerHealth = originalPlayerHealth;
            Die();
        }
    }

    void InvEnd()
    {
        dmgInv = false;
    }

    public void PlayerTakeDamage(int amount)
    {
        dmgInv = true;
        playerHealth -= amount;
        Invoke("InvEnd", invTime);
    }

    void Die()
    {
        Player.transform.position = startPos;
    }
}
