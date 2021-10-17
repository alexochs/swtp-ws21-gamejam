using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private GameObject charakter;

    private float xMin = -2000;
    private float xMax = 2000;
    private float yMin = 0;
    private float yMax = 30;

    private float xOffset = 1;
    private float yOffset = 2;

    // Start is called before the first frame update
    void Start(){

        charakter = GameObject.Find("Sword");
        gameObject.transform.Rotate(new Vector3(5, 7.5f, 0));
    }
  

    // Update is called once per frame
    void Update()
    {

        float x = charakter.transform.position.x;
        float y = Mathf.Clamp(charakter.transform.position.y, yMin,yMax);

        gameObject.transform.position = new Vector3(x + xOffset,y + yOffset,gameObject.transform.position.z);
    }
}
