using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSword : MonoBehaviour
{

    public int height ;
    public float maxHeight;

    float swordAngle;

    Camera cam;

    Vector3 anchorVector = new Vector3();





    
    // Start is called before the first frame update
    void Start()
    {

       cam = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {
       //Movement

        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        
        Vector3 moveDirection = new Vector3(xInput,yInput, 0.0f);
        transform.position += moveDirection ;


      //Anker

      anchorVector = GetComponentInChildren<Transform>().position;



      //Schwertrotation
       Vector2 mousePos = new Vector2();
       mousePos = Input.mousePosition;
       

        Vector3 mouse = new Vector3(mousePos.x-Screen.width/2,mousePos.y-Screen.height/2,transform.position.z);
        Vector3 direction = mouse - anchorVector ;

        float angle;

        angle = Mathf.Atan2(mouse.y,mouse.x) * Mathf.Rad2Deg-90;

        transform.rotation = Quaternion.Euler(0,0,angle);


        print(mousePos);

    }

    void FixedUpdate(){

      


        



    }
}
