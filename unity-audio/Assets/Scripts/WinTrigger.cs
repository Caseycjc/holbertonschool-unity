using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public Timer timer;
    public BackgroundMusicController bgmController;  // Reference to the music controller

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            timer.startTimer = false; // Stop the timer
            
            timer.timerText.fontSize = 60; // Change the font size
            timer.timerText.color = Color.green; // Change the color to green

            bgmController.StopMusic();  // Stop the background music
        }
    }
}
