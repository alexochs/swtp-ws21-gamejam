using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxForceUp : MonoBehaviour
{
    public GameObject pickupEffect;

    public float multiplier = 1.4f;
    public float duration = 5f;

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            StartCoroutine(Pickup(other));//Start Coroutine wenn added
        }
    }
    
    IEnumerator Pickup(Collider player){ //IEnumerator
        Debug.Log("PowerUP picked up!");
        //Spawn a cool effect
        GameObject clone = Instantiate(pickupEffect, transform.position, transform.rotation);
        ParticleSystem.MainModule particle = clone.GetComponent<ParticleSystem>().main;

        //Apply effect to the player

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;


  
        player.GetComponent<MoveSword>().maxForce = 20;
        yield return new WaitForSeconds(duration);
        player.GetComponent<MoveSword>().maxForce = 10;


        //Destroy the Object
        Destroy(clone, particle.duration);
        Destroy(gameObject);
        
    }
}
