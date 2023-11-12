using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player; // The player object the camera will follow
    public float turnSpeed = 4.0f; // Speed of camera turning when mouse moves in along an axis
    private Vector3 offset; // The offset between player and camera

    // Run this logic before any other updates
    private void Start()
    {
        offset = new Vector3(player.transform.position.x, player.transform.position.y + 8.0f, player.transform.position.z - 8.0f);
    }

    private void LateUpdate()
    {
        // Offset the camera behind the player by adding to the player's position
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
        transform.position = player.transform.position + offset; 
        transform.LookAt(player.transform.position);
    }
}
