using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp : MonoBehaviour
{
    public GameObject pickupEffect;

    public float multiplier = 1.4f;
    public float duration = 4f;

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


  
        player.GetComponent<MoveSword>().hp = player.GetComponent<MoveSword>().maxhp;
        yield return new WaitForSeconds(duration);



        //Destroy the Object
        Destroy(clone, particle.duration);
        Destroy(gameObject);
        
    }

}
