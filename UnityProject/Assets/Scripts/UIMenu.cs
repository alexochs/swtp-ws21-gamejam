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
    public int maxlife;
    public int life;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        slider1.maxValue = maxlife;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score:  " + score.ToString();
        slider1.value = life;

        if (life <= 0)
        {
            UI.SetActive(false);
            deathMenuScore.text = score.ToString();
            deathMenu.SetActive(true);
        }
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
