using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    public GameObject UI;
    public GameObject deathMenu;
    public TextMeshProUGUI deathMenuScore;
    public TextMeshProUGUI scoreText;
    public Slider slider1;
    public MoveSword moveSword;
    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        slider1.maxValue = moveSword.maxhp;
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score:  " + gm.GetPoints().ToString();
        slider1.value = moveSword.hp;

        if (moveSword.hp <= 0)
        {
            UI.SetActive(false);
            deathMenuScore.text = gm.GetPoints().ToString();
            deathMenu.SetActive(true);
        }
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
