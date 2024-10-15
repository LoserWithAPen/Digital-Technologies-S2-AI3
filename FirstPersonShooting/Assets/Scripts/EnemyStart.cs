using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStart : MonoBehaviour
{
    void Start()
    {
        gameObject.AddComponent<NavMeshAgent>();
        gameObject.AddComponent<EnemyAIMelee>();
    }
}
