using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    //settings
    public float blockSize;
    public float bottomPostion;
    public int startingBlocks;
    public int floatingBlockChance;
    public int gapChance;
    public int maxGaps;
    public int maxFloorHeight = 5;
    public int steps;
    public float spawnDistance;

    public GameObject[] floor;
    public GameObject[] floatingBlock;

    //x and y position of the last instantiated Blocks
    int lastFloorPosx;
    int lastFloorPosy;
    
    GameObject player;


    void Start()
    {
        lastFloorPosy = 0;
        generate(0, startingBlocks);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            //generate(lastFloorPosx, 20);
            Debug.Log(lastFloorPosx);
        }
        Debug.Log(Vector3.Distance(player.transform.position, new Vector3(lastFloorPosx*blockSize, player.transform.position.y, player.transform.position.z)));
        if(Vector3.Distance(player.transform.position, new Vector3(lastFloorPosx*blockSize, player.transform.position.y, player.transform.position.z)) <= spawnDistance){
            generate(lastFloorPosx, 25);
        }   
    }


    public void generate(int startingpos, int amount){
        //counter for gaps
        int blocked = 0;
        for(int i = startingpos; i<startingpos+amount; i++){
            Debug.Log(i);
            lastFloorPosx = i;
            if(blocked <= 0){
                //check if you generate gaps or floor
                if(Random.Range(0,100)>gapChance){
                    //randomly increase or decrease floor height every 4 Blocks
                    if(lastFloorPosx%steps == 0 && lastFloorPosx != 0) lastFloorPosy += Random.Range(-3, 4);

                    if(lastFloorPosy<0) lastFloorPosy = 0;
                    if(lastFloorPosy>maxFloorHeight)lastFloorPosy = maxFloorHeight;

                    //determine two spawns for top and bottom floor tile
                    Vector3 spawnPos1 = new Vector3(lastFloorPosx*blockSize, bottomPostion + blockSize*lastFloorPosy, 0);
                    Instantiate(floor[Random.Range(0,floor.Length)], spawnPos1, Quaternion.identity);
                }
                else{
                    //generate 1-x gaps
                    blocked = Random.Range(1,maxGaps);
                }

                
            }
            //generate Floating
            if(Random.Range(0,100)<floatingBlockChance) generateFloating();
            blocked--;
        }
    }

    public void generateFloating(){
        //spawn 2-4 floating at random height
        int height = Random.Range(2,7);
        for(int i = 0; i < Random.Range(1,5); i++){
            Instantiate(
                floatingBlock[Random.Range(0,floatingBlock.Length)], 
                new Vector3((lastFloorPosx+i)*blockSize, bottomPostion + blockSize*(lastFloorPosy+height), 0), 
                Quaternion.identity
            );
        }
    } 

}
