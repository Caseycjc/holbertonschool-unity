using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public Timer timer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            timer.startTimer = false; // Stop the timer
            
            timer.timerText.fontSize = 60; // Change the font size
            timer.timerText.color = Color.green; // Change the color to green
        }
    }
}
