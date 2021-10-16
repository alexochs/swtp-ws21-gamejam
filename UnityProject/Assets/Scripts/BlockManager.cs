using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{

    public float timePerBlock;
    public List<GameObject> blocks;
    float timer;
    int currentx = 0;

    private void Awake()
    {
        blocks = new List<GameObject>();
        timer = timePerBlock;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0){
            timer=timePerBlock;
            clearBlocks();
        } 
    }

    void clearBlocks(){
        List<GameObject> blocksToRemove = new List<GameObject>();
        foreach (GameObject block in blocks)
        {
            Block blockScript = block.GetComponent<Block>();
            if(blockScript.xPosition == currentx){
                blocksToRemove.Add(block);
            }
            else break; 
        }

        foreach (GameObject block in blocksToRemove)
        {
            Block blockScript = block.GetComponent<Block>();
            blocks.Remove(block);
            blockScript.die(); 
        }
        currentx++;
    }

}
