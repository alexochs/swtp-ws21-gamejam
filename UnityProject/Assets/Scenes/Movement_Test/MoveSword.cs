using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSword : MonoBehaviour
{

    public int height ;
    public float maxHeight;
    public float speed;

    public float cooldownJump = 5;
   

    private float timeGone;

    float swordAngle;

    Camera cam;

    Vector3 anchorVector = new Vector3();
    Rigidbody rb;
    Rigidbody torso;
    Rigidbody leftLeg;
    Rigidbody rightLeg;



    
    // Start is called before the first frame update
    void Start()
    {

     
    

        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        torso = GameObject.Find("spine.003").GetComponent<Rigidbody>();
        leftLeg = GameObject.Find("shin.L").GetComponent<Rigidbody>();
        rightLeg = GameObject.Find("shin.R").GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
       //Movement

      // cooldownJump = 5;

        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        
        //Vector3 moveDirection = new Vector3(xInput,yInput, 0.0f);
        //transform.position += moveDirection/30 ;

        if(transform.position.z != 0) transform.position = new Vector3(transform.position.x, transform.position.y, 0);
      //Anker

      anchorVector = GetComponentInChildren<Transform>().position;


      // Attachement

      GameObject k = GameObject.Find("hand.R");
      Vector3 zwischenvektor = anchorVector;
      // Nachjustierung für Hand

      //zwischenvektor.y +=  -0.3f;

      k.transform.position = zwischenvektor;

        
        Vector2 torsoForce = torso.velocity*torso.mass;
        Vector2 legLForce = leftLeg.velocity*leftLeg.mass; 
        Vector2 legRForce = rightLeg.velocity*rightLeg.mass;

        Vector2 totalForce = (torsoForce+legLForce+legRForce)*0.05f;
        



      //Schwertrotation
       Vector2 mousePos = new Vector2();
       mousePos = Input.mousePosition;
       

        Vector3 mouse = new Vector3(mousePos.x-Screen.width/2,mousePos.y-Screen.height/2,transform.position.z);
        Vector3 direction = mouse - anchorVector ;

        float angle;

        angle = Mathf.Atan2(mouse.y,mouse.x) * Mathf.Rad2Deg-90;

        transform.rotation = Quaternion.Euler(0,0,angle);

        
        

        
        
//Debug.Log(Vector3.right + new Vector3(totalForce.x, totalForce.y, 0));
        //rb.AddForce(-totalForce);



        if(Input.GetMouseButtonDown(0)&& timeGone > cooldownJump){

            
            //print("Zeit : "+Time.time+"  timeForNextJump"+timeForNextJump);

            //
            
            timeGone = 0;

            //timeForNextJump = (Time.time- time) +cooldownJump;



            // Impuls 



            rb.AddForce(direction*0.05f, ForceMode.Impulse);
        }else{
           
            timeGone = timeGone+Time.deltaTime;
        }

        Debug.Log("timeGone : "+ timeGone + "coolDownJump :  "+ cooldownJump);
    }

    void FixedUpdate(){

      
        

        



    }
}
