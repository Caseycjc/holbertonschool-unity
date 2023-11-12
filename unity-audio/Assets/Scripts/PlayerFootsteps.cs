using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    public AudioSource footstepSource;
    public AudioClip grassFootsteps;
    public AudioClip rockFootsteps;
    public LayerMask whatIsGrass;
    public LayerMask whatIsRock;

    private Animator animator;
    private PlayerController playerController;  // Reference to PlayerController script

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        playerController = GetComponent<PlayerController>();  // Get the PlayerController component
    }

    void Update()
    {
        CheckRunning();
    }

void CheckRunning()
{
    if (animator.GetBool("IsMoving") && !footstepSource.isPlaying && playerController.IsPlayerGrounded())
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            if (whatIsGrass == (whatIsGrass | (1 << hit.collider.gameObject.layer)))
            {
                footstepSource.clip = grassFootsteps;
            }
            else if (whatIsRock == (whatIsRock | (1 << hit.collider.gameObject.layer)))
            {
                footstepSource.clip = rockFootsteps;
            }
            footstepSource.Play();
        }
    }
    else if(!animator.GetBool("IsMoving") || !playerController.IsPlayerGrounded())
    {
        footstepSource.Stop();
    }
}
}
