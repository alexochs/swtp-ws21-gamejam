using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IngameMenu : MonoBehaviour
{
    Canvas menuCanvas;
    public Slider volumeSlider;

    void Start()
    {
        menuCanvas = GetComponent<Canvas>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            volumeSlider.value = FindObjectOfType<Soundmanager>().volume;
            toggleMenu();
        }
    }

    public void toggleMenu()
    {
        menuCanvas.enabled = !menuCanvas.enabled;
        Time.timeScale = menuCanvas.enabled ? 0f : 1f;
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void changeVolume()
    {
        FindObjectOfType<Soundmanager>().volume = volumeSlider.value;
    }
}
