using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingBlock : Block
{
    public bool active;
    public float timer;

    Slider hpbar;

    private void Start()
    {
        hpbar = GetComponentInChildren<Slider>();
        hpbar.maxValue = timer;
    }
    
    void Update()
    {
        if(active) timer -= Time.deltaTime;
        hpbar.value = timer;
        if(timer <= 0f){
            die();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") active = true;
    }
}
