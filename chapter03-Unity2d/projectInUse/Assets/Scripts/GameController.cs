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
    [SerializeField] Text gameoverText;

    private void Start()
    {
        gameoverText.enabled = false;
        DisplayStatus();
    }

    public void PlayerHit()
    {
        lives--;
        DisplayStatus();
        if (lives <= 0)
            StartCoroutine(FinishGame());
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

    IEnumerator FinishGame()
    {
        gameoverText.enabled = true;
        Time.timeScale = 0.01f;
        yield return new WaitForSecondsRealtime(4);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

}
