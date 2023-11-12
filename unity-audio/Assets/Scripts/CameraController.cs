using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float turnSpeed = 4.0f;
    private bool isInverted = false;
    private Vector3 offset;

    private void Start()
    {
        // Load the isInverted setting
        isInverted = PlayerPrefs.GetInt("InvertY", 0) == 1;

        offset = new Vector3(player.transform.position.x, player.transform.position.y + 8.0f, player.transform.position.z - 8.0f);
    }

    private void LateUpdate()
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;

        // Y-axis inversion
        if (isInverted)
        {
            offset = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * turnSpeed, Vector3.right) * offset;
        }
        else
        {
            offset = Quaternion.AngleAxis(-Input.GetAxis("Mouse Y") * turnSpeed, Vector3.right) * offset;
        }

        transform.position = player.transform.position + offset; 
        transform.LookAt(player.transform.position);
    }
}
