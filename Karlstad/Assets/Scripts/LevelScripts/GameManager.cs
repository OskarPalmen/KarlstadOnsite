using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gameStarted = false; // flag to indicate when the game has started
    public bool gameOver = false; // flag to indicate when the game is over
    public GameObject startButton; // reference to the start button
    public TMP_Text scoreText; // reference to the score text
    private int score = 0; // current score
    public TMP_Text highScoreText; // reference to the high score text
    private int highScore = 0; // current high score

    void Awake()
    {
        Time.timeScale = 0; // pause the game at start
        highScore = PlayerPrefs.GetInt("HighScore", 0); // get the saved high score
        highScoreText.text = "High Score: " + highScore; // display the high score
    }

    void Update()
    {
        if (gameStarted) // check if the game has started
        {
            if (!Time.timeScale.Equals(0)) // check if the game is running
            {
                score += 1; // increase score by 1 every second
                scoreText.text = "Score:" + score; // update the score text

                if (score > highScore) // check if the current score is higher than the high score
                {
                    highScore = score; // update the high score
                    highScoreText.text = "High Score: " + highScore; // update the high score text
                    PlayerPrefs.SetInt("HighScore", highScore); // save the new high score
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.R)) // check if the player pressed the R key
        {
            Restart(); // restart the game
        }

        if (Input.GetKeyDown(KeyCode.P)) // check if the player pressed the P key
        {
            ResetHighScore(); // reset the high score
        }

    }

    void ResetHighScore()
    {
        highScore = 0; // reset the high score
        highScoreText.text = "High Score: " + highScore; // update the high score text
        PlayerPrefs.SetInt("HighScore", highScore); // save the new high score
    }


    void Restart()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // get the current scene index
        SceneManager.LoadScene(currentSceneIndex); // reload the current scene
    }

    public void StartGame()
    {
        gameStarted = true; // set the game as started
        Time.timeScale = 1; // resume the game
        startButton.SetActive(false); // hide the start button
        scoreText.gameObject.SetActive(true); // make the score text visible
    }

    public void GameOver()
    {
        gameOver = true; // set the game as over
    }
}