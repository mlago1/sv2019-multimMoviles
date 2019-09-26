using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int lives = 3;
    private int points = 0;
    [SerializeField] Text scoreboardText;

    private void Start()
    {
        DisplayStatus();
    }

    public void PlayerHit()
    {
        lives--;
        DisplayStatus();
        if (lives <= 0)
            SceneManager.LoadScene(0);
    }

    public void EnemyHit()
    {
        points += 10;
        DisplayStatus();
    }

    void DisplayStatus()
    {
        scoreboardText.text = "Points " + points +
            "   Lives " + lives;
    }

}
