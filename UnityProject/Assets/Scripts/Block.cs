using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public float friction;
    public int xPosition;
    public int yPosition;


    float destructionTimer = 0f;


    public void die(){
        //animation
        Destroy(this.gameObject, destructionTimer);
    }

    public void resize(float size){
        this.transform.localScale = new Vector3(size,size,size);
    }
}
