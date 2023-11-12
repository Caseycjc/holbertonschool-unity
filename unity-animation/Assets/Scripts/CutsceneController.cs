using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject player;       
    public GameObject timerCanvas;
    private Animator animator;
    private PlayerController playerController;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerController = player.GetComponent<PlayerController>();
        
        // Initialization
        mainCamera.SetActive(false);
        playerController.enabled = false;
        timerCanvas.SetActive(false);
    }

    private void Update()
    {
        // Check if the Level01 animation has finished playing
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1 && !animator.IsInTransition(0))
        {
            // Enable Main Camera
            mainCamera.SetActive(true);
            
            // Disable Cutscene Camera
            gameObject.SetActive(false);
            
            // Enable PlayerController
            playerController.enabled = true;

            // Enable TimerCanvas but don't start it
            timerCanvas.SetActive(true);

            // Disable CutsceneController script
            this.enabled = false;
        }
    }
}
