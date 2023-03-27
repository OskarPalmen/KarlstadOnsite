using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverScreen; // Reference to the game over screen object.
    [SerializeField] TMP_Text currentScore; // Reference to the current score display object.
    [SerializeField] TMP_Text finalScore; // Reference to the final score display object.

    public void SetGameOver()
    {
        gameOverScreen.SetActive(true); // Activate the game over screen.

        finalScore.text = currentScore.text; // Set the final score display to the current score.

        currentScore.gameObject.SetActive(false); // Deactivate the current score display.

        Time.timeScale = 0; // Freeze the game by setting the time scale to 0.
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Resume the game by setting the time scale to 1.

        SceneManager.LoadScene(0); // Load the first scene to restart the game.
    }

    public void QuitGame()
    {
        Debug.Log("Quit"); // Output "Quit" to the console for debugging purposes.

        Application.Quit(); // Quit the application.
    }
}
