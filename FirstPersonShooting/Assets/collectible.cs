using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectible : MonoBehaviour
{
    bool hit = false;
    public int scoreValue = 1;


    private void OnTriggerEnter(Collider other)
    {

        if(other.transform.root.CompareTag("Player"))
        {
            hit = true;
            

        }
        
    }

    // Update is called once per frame
    void Update()
    {Debug.Log("Hit " + hit);
        if(hit == true)
        {
            GameManager.instance.ChangeScore(scoreValue);
            Destroy(gameObject);
        }
    }
}
