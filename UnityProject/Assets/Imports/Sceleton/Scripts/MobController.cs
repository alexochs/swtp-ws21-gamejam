using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobController : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private Transform target = null; 
    [SerializeField] private LayerMask playerMask;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space)) anim.SetTrigger("Attack");
        if (target != null)
        {
            if(Mathf.Round(target.position.y)  == Mathf.Round(gameObject.transform.position.y)) transform.LookAt(target);
        }
        
    }

    private void OnTriggerStay(Collider other) {
        if(other.gameObject.layer == 6) anim.SetTrigger("Attack");
    }
    
}
