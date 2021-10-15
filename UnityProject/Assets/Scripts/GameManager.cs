using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        points += 1;
    }

    public string getStatus()
    {
        return this.status;
    }

    public void setStatus(string status)
    {
        this.status = status;
    }

    public int getPoints()
    {
        return this.points;
    }

    public void setPoints(int points)
    {
        this.points = points;
    }

    public void addPoints(int points)
    {
        this.points += points;
    }

    private void Reset()
    {
        this.status = "Menu";
        this.points = 0;
    }
}
