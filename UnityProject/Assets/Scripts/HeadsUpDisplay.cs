using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadsUpDisplay : MonoBehaviour
{
    private GameManager gameManager;
    private TextMesh pointsText;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        pointsText = (TextMesh)GameObject.Find("Points").GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        pointsText.text = "Points: " + gameManager.GetPoints().ToString();
    }
}
