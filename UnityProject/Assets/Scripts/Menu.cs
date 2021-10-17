using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Slider volumeSlider;

    void Start()
    {
        volumeSlider.value = FindObjectOfType<Soundmanager>().volume;
    }

    void Update()
    {

    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void loadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void changeVolume()
    {
        FindObjectOfType<Soundmanager>().volume = volumeSlider.value;
    }
}
