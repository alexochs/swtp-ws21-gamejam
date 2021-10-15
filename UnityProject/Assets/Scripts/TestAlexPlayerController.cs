using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAlexPlayerController : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 8;

    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        direction.x = hInput * speed;

        controller.Move(direction * Time.deltaTime);
    }
}
