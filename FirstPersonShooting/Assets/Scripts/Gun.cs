using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    private CharacterInput controls;
    public float damage = 10f;
    public float range = 100f;
    public Camera fpsCam;

    private void Awake()
    {
        controls = new CharacterInput();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
    
    void Update()
    {
        if (controls.Player.Shoot.triggered)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Target enemy = hit.transform.GetComponent<Target>();
            if (enemy)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}
