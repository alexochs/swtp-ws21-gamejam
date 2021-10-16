using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : Block
{

    public GameObject[] probs;

    private void Awake()
    {
        if(Random.Range(0,100)<15){
            GameObject prob = Instantiate(probs[Random.Range(0,probs.Length)], new Vector3(transform.position.x, transform.position.y+0.4f, transform.position.z+0.5f), Quaternion.identity, transform);
        }
    }
    
}
