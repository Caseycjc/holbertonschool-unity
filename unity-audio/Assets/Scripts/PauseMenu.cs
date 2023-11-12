using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas;
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseCanvas.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {
        pauseCanvas.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    // Added functions
    public void Restart()
    {
        Time.timeScale = 1f; // Unpause time
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

    public void MainMenu()
    {
        Time.timeScale = 1f; // Unpause time
        SceneManager.LoadScene("MainMenu"); // Load the MainMenu scene
    }

    public void Options()
    {
        Time.timeScale = 1f; // Unpause time
        SceneManager.LoadScene("Options"); // Load the Options scene
    }
}
