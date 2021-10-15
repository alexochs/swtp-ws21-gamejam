using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private string status;
    private int points;

    void Start()
    {
        DontDestroyOnLoad(this); // keeps the GameManager between scenes
        Reset();
    }

    void Update()
    {
        if (this.status == "INGAME") points++;
    }

    public string GetStatus()
    {
        return this.status;
    }

    public void SetStatus(string status)
    {
        this.status = status;
    }

    public int GetPoints()
    {
        return this.points;
    }

    public void SetPoints(int points)
    {
        this.points = points;
    }

    public void AddPoints(int points)
    {
        this.points += points;
    }

    public void StartNewGame()
    {
        LoadScene("GameManagerScene");
        this.status = "INGAME";
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    private void Reset()
    {
        this.status = "Menu";
        this.points = 0;
    }
}
