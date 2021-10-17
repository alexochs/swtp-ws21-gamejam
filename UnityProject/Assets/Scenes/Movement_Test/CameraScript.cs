using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private GameObject charakter;

    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    public float xOffset;
    public float yOffset;

    // Start is called before the first frame update
    void Start(){

        charakter = GameObject.Find("Sword");
    }
  

    // Update is called once per frame
    void Update()
    {

        float x = Mathf.Clamp(charakter.transform.position.x, xMin,xMax);
        float y = Mathf.Clamp(charakter.transform.position.y, yMin,yMax);

        gameObject.transform.position = new Vector3(x + xOffset,y + yOffset,gameObject.transform.position.z);
    }
}
