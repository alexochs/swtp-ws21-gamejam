using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    public GameObject deathEffect;

    private void OnTriggerEnter(Collider other) {
        
        if (other.tag == "Body")
        {
            Debug.Log("attk");
            //Instantiate(deathEffect, transform.position, transform.rotation);
            GameObject.FindGameObjectWithTag("Player").GetComponent<MoveSword>().takeDamage();
            //trigger GameOver
        }
    }

    
}
