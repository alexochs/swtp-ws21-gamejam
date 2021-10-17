using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    public GameObject deathEffect;
    public bool dead;

    private void OnTriggerEnter(Collider other) {
        
        if (other.tag == "Body" && !dead)
        {
            Debug.Log("attk");
            //Instantiate(deathEffect, transform.position, transform.rotation);
            GameObject.FindGameObjectWithTag("Player").GetComponent<MoveSword>().takeDamage();
            //trigger GameOver
        }
    }

    
}
