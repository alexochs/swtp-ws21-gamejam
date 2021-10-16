using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    public GameObject deathEffect;

    private void OnTriggerEnter(Collider other) {
        
        if (other.gameObject.layer == 6)
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(other.transform.parent.gameObject);
            //trigger GameOver
        }
    }

    
}
