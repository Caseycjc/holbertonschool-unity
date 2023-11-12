using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    public Timer timer;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            timer.StartTimer();
        }
    }
}
