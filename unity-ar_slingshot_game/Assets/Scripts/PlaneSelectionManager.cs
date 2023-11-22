using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlaneSelectionManager : MonoBehaviour
{
    public ARPlaneManager planeManager;
    public TargetSpawner targetSpawner;

    public GameObject startButton;
    public GameObject restartButton;
    public GameObject stopButton;
    public GameObject scoreText;
    public GameObject ammoText;

    private ARPlane selectedPlane;

    void Awake()
    {
        startButton.SetActive(false);
        restartButton.SetActive(false);
        stopButton.SetActive(false);
        scoreText.SetActive(false);
        ammoText.SetActive(false);
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    ARPlane plane = hit.transform.GetComponent<ARPlane>();
                    if (plane != null && selectedPlane == null) // Check if no plane has been selected yet
                    {
                        SelectPlane(plane);
                    }
                }
            }
        }
    }

    private void SelectPlane(ARPlane plane)
    {
        if (selectedPlane != null)
        {
        // Hides the previously selected plane
        }

        selectedPlane = plane;

         // Disables further plane detection
        planeManager.enabled = false;

        // Activates UI elements
        startButton.SetActive(true);
        restartButton.SetActive(true);
        stopButton.SetActive(true);
        scoreText.SetActive(true);
        ammoText.SetActive(true);
    }

}