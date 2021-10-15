using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject pickupEffect;

    public float multiplier = 1.4f;
    public float duration = 4f;

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            Pickup(other);//Start Coroutine wenn added
        }
    }
    
    void Pickup(Collider player){ //IEnumerator
        Debug.Log("PowerUP picked up!");
        //Spawn a cool effect
        Instantiate(pickupEffect, transform.position, transform.rotation);

        //Apply effect to the player
        player.transform.localScale *= multiplier;

        /*
        Player stats = player.GetComponent<PlayerStats>();
        stats.health *= multiplier;



        WAIT X AMOUNT OF SECONDS
        yield return new WaitForSeconds(duration);

        stats.health /= multiplier;
        */

        //Destroy the Object
        Destroy(gameObject);
    }
}
