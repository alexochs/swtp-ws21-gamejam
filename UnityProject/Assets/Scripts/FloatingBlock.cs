using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingBlock : Block
{
    public bool active;
    public float timer;
    public float moveSpeed;
    public bool movingX;
    public bool movingY;
    float maxX;
    float minX;
    float maxY;
    float minY;
    bool moveToggle = true;

    Slider hpbar;

    private void Start()
    {
        hpbar = GetComponentInChildren<Slider>();
        hpbar.maxValue = timer;

        maxX = transform.position.x+3;
        minX = transform.position.x-3;
        maxY = transform.position.y+3;
        minY = transform.position.y-2;
    }
    
    void Update()
    {
        if(active) timer -= Time.deltaTime;
        hpbar.value = timer;
        if(timer <= 0f){
            this.gameObject.SetActive(false);
        }

        if(movingX){
            if(transform.position.x< maxX && moveToggle) transform.position = new Vector3(transform.position.x+moveSpeed*Time.deltaTime, transform.position.y, transform.position.z);
            else if(transform.position.x>= maxX && moveToggle) moveToggle = !moveToggle;

            if(transform.position.x> minX && !moveToggle) transform.position = new Vector3(transform.position.x-moveSpeed*Time.deltaTime, transform.position.y, transform.position.z);
            else if(transform.position.x<= minX && !moveToggle) moveToggle = !moveToggle;
        }
        if(movingY){
            if(transform.position.y< maxY && moveToggle) transform.position = new Vector3(transform.position.x, transform.position.y+moveSpeed*Time.deltaTime, transform.position.z);
            else if(transform.position.y>= maxY && moveToggle) moveToggle = !moveToggle;

            if(transform.position.y> minY && !moveToggle) transform.position = new Vector3(transform.position.x, transform.position.y-moveSpeed*Time.deltaTime, transform.position.z);
            else if(transform.position.y<= minY && !moveToggle) moveToggle = !moveToggle;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            GetComponentInChildren<Canvas>().enabled = true;
            active = true;
        } 
    }
}
