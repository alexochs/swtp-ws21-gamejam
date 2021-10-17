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
        target = GameObject.Find("Sword").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space)) anim.SetTrigger("Attack");
        if (target != null)
        {
            if(target.position.x < transform.position.x) transform.rotation = Quaternion.Euler(0, 270, 0);
            if(target.position.x > transform.position.x) transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        
    }

    private void OnTriggerStay(Collider other) {
        if(other.tag == "Body"){
            anim.SetTrigger("Attack");
        } 
    }

    public void die(){
        Destroy(this.gameObject);
    } 
    


}
