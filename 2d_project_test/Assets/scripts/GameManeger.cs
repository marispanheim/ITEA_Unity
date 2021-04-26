using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManeger : MonoBehaviour
{
    public int lives;
    public int score;
    public TextMeshProUGUI livesText;
    
    public TextMeshProUGUI scoreText;
    public bool gameOver;
    public GameObject gameOverPanel;
    public int bricksCounter; 
    

    void Start()
    {
        livesText.text = "Lives: " + lives;
        scoreText.text = "Score: " + score;
        bricksCounter = GameObject.FindGameObjectsWithTag("Bricks").Length;
    }


    void Update()
    {
       

    }
    public void UpdateLives(int changeInLives)
    {
        lives += changeInLives;
        if (lives <= 0)
        {
            lives = 0;
            GameOver();
        }
        livesText.text = "Lives: " + lives;
    }
    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "score: " + score;
    }
    public void UpdateBricks()
    {
        bricksCounter--;
        if (bricksCounter <=0 )
        {
            GameOver();
        }
    }
    void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
    }
    public void Retry()
    {
        SceneManager.LoadScene("arcana");
    }
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
}
