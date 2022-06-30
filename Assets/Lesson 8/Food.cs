using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    public int value = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Target")) 
        {
            audioSource.Play();
        }

        if (collision.gameObject.CompareTag("Target"))
        {
            if (Scoreboard.scoreboard_instance.gameStarted == false)
            {
                Scoreboard.scoreboard_instance.ResetGame();
            }
           
            Scoreboard.scoreboard_instance.IncrementScore(value);

        }

    }
}
