using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour
{
    public float spinSpeed = 100f;

    public float yOffset;
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
        transform.Rotate(0f,spinSpeed * Time.deltaTime,0f, Space.Self);
        xPos = transform.position.x;
        zPos = transform.position.z;
        yPos = Mathf.Sin(Time.time * frequency)* amplitude + yOffset;
        transform.position = new Vector3(xPos,yPos,zPos);

    }
}
