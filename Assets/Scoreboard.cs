using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    public int score;

    public float timer = 10f;

    public TextMeshProUGUI scoreboardDisplay;

    public bool gameStarted = false;

    public static Scoreboard scoreboard_instance;

    // Start is called before the first frame update
    void Awake()
    {
        if (scoreboard_instance == null)
        {
            scoreboard_instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStarted == true)
        {
            timer -= Time.deltaTime;

            if (timer < 0)
            {
                timer = 0;
                gameStarted = false;
            }

            scoreboardDisplay.text = "Timer: " + timer.ToString("F2") + "\nScore: " + score;
        }
    }

    public void IncrementScore(int value)
    {
        score = score + value;
    }   

    public void ResetGame()
    {
        gameStarted = true;
        timer = 10f;
        score = 0;
    }

    

}
