using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public float friction;

    int xPosition;
    int yPosition;
    float destructionTimer = 0f;

    private void Awake()
    {
        
    }

    public void die(){
        //animation
        Destroy(this.gameObject, destructionTimer);
    }

    public void resize(float size){
        this.transform.localScale = new Vector3(size,size,size);
    }
}
