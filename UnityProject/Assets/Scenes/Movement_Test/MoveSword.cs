using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveSword : MonoBehaviour
{

    public int height;
    public float maxForce;
    public float forceRegen;

    public float cooldownJump = 5;
   

    private float timeGone = 5;
    public GameObject forceSlider;

    private GameManager gameManager;

    float swordAngle;
    public float maxhp = 90;
    public float hp;
    bool dead;

    Camera cam;

    Vector3 anchorVector = new Vector3();
    Rigidbody rb;
    Rigidbody torso;
    Rigidbody leftLeg;
    Rigidbody rightLeg;
    
    Slider forceBar;

    float forcePool = 0f;
    float forceMultiplier;
    float forceRate = 25f;

    float dmgTimer;


    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        hp = maxhp;
        forceBar = forceSlider.GetComponent<Slider>();
        forceBar.maxValue = maxForce;
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
        forceBar.value = forcePool;
        dmgTimer -= Time.deltaTime;

        if(forcePool<=maxForce) forcePool += forceRegen*Time.deltaTime;

        if(Input.GetMouseButton(0) && forcePool>0 && !dead){
            forceMultiplier += forceRate*Time.deltaTime;
            forcePool -= forceRate*Time.deltaTime;
            if(forceMultiplier >= maxForce) forceMultiplier = maxForce;
        }

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
        
        if(transform.position.y <= -20) hp = 0;


      //Schwertrotation
       Vector2 mousePos = new Vector2();
       mousePos = Input.mousePosition;
       

        Vector3 mouse = new Vector3(mousePos.x-Screen.width/2,mousePos.y-Screen.height/2,transform.position.z);
        Vector3 direction = mouse - anchorVector ;

        float angle;

        angle = Mathf.Atan2(mouse.y,mouse.x) * Mathf.Rad2Deg-90;

        transform.rotation = Quaternion.Euler(0,0,angle);

        



        if(Input.GetMouseButtonUp(0)&& timeGone > cooldownJump){

            
            timeGone = 0;

            rb.AddForce(direction.normalized*forceMultiplier, ForceMode.Impulse);
            forceMultiplier = 0;
        }else{
           
            timeGone = timeGone+Time.deltaTime;
        }

        //Debug.Log("timeGone : "+ timeGone + "coolDownJump :  "+ cooldownJump);
    
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Skeleton"){
            other.gameObject.GetComponent<Animator>().enabled = false;
            other.gameObject.GetComponent<Rigidbody>().detectCollisions = false;
            Destroy(other.gameObject, 5);
        }
    }

    public void takeDamage(){
        if(dmgTimer <=0){
            hp -= 30;
            if(hp <= 0) die();
            dmgTimer = 0.5f;
        }
    }

    void die(){
        dead = true;
        GetComponent<MeshCollider>().enabled = false;
    }
}
