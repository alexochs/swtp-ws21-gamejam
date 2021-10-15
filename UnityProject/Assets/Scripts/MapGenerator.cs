using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public float blockSize;
    public float bottomPostion;
    public int startingBlocks;
    public int floatingBlockChance;
    public int gapChance;
    public int maxGaps;

    public GameObject[] floor;
    public GameObject[] floatingBlock;

    int maxFloorHeight = 5;

    //x and y position of the last instantiated Blocks
    int lastFloorPosx;
    int lastFloorPosy;
    


    void Start()
    {
        lastFloorPosy = 0;
        generateFloor(startingBlocks);
    }

    
    void Update()
    {
        
    }


    void generateFloor(int amount){
        for(int i = lastFloorPosx; i<amount; i++){
            lastFloorPosx = i;
            //check if you generate gaps or floor
            if(Random.Range(0,100)>gapChance){
                //randomly increase or decrease floor height every 4 Blocks
                if(lastFloorPosx%4 == 0) lastFloorPosy += Random.Range(-3, 4);

                if(lastFloorPosy<0) lastFloorPosy = 0;
                if(lastFloorPosy>maxFloorHeight)lastFloorPosy = maxFloorHeight;

                //determine two spawns for top and bottom floor tile
                Vector3 spawnPos1 = new Vector3(lastFloorPosx + blockSize, bottomPostion + blockSize*lastFloorPosy, 0);
                Instantiate(floor[Random.Range(0,floor.Length)], spawnPos1, Quaternion.identity);
            }
            else{
                //generate 1-x gaps
                i += Random.Range(1,maxGaps);
            }
        }
    }
}
