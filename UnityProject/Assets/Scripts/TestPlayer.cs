using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.layer == 7)
        {
            if(other.gameObject.GetComponent<Animator>() != null) other.gameObject.GetComponent<Animator>().enabled = false;   
        }
    }
}
