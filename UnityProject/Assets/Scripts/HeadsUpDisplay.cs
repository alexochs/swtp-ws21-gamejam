using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadsUpDisplay : MonoBehaviour
{
    public GameManager gameManager;

    private TextMesh pointsText;

    void Start()
    {
        pointsText = (TextMesh)GameObject.Find("Points").GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        pointsText.text = "Points: " + gameManager.getPoints().ToString();
    }
}
