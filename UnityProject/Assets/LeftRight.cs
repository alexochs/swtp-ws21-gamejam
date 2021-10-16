using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRight : MonoBehaviour
{
    public float xOffset;
    public float amplitude = 0.1f;
    public float frequency = 100f;
    private float xPos;
    private float yPos;
    private float zPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xPos = Mathf.Sin(Time.time * frequency)* amplitude + xOffset;
        zPos = transform.position.z;
        yPos = transform.position.y;
        transform.position = new Vector3(xPos,yPos,zPos);
    }
}
