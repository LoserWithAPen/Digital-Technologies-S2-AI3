using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DragonStartUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("delayAddingScript", 1.5f);
    }

    void delayAddingScript()
    {
        gameObject.AddComponent<NavMeshAgent>();
  
            gameObject.AddComponent<DragonAIScript>();
            Destroy(GetComponent<Rigidbody>());
    }
}
