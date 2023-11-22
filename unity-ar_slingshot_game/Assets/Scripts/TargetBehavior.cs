using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class TargetBehavior : MonoBehaviour
{
    public float speed = 1f;
    private Vector3 direction;
    private ARPlane plane;
    private Vector3 minBoundary;
    private Vector3 maxBoundary;

    public void Initialize(ARPlane assignedPlane)
    {
        plane = assignedPlane;

        // calculates boundary
        var center = plane.transform.position;
        var extents = plane.extents;

        minBoundary = center - new Vector3(extents.x, 0f, extents.y);
        maxBoundary = center + new Vector3(extents.x, 0f, extents.y);
        
        // Random initial direction
        direction = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
    }

    void Update()
    {
        if (plane == null) return;

        // moves the target within the plane
        transform.position += direction * speed * Time.deltaTime;

        // lets the target bounce off the wall when it gets to the edge
        if (transform.position.x < minBoundary.x || transform.position.x > maxBoundary.x)
        {
            direction.x = -direction.x;
        }
        if (transform.position.z < minBoundary.z || transform.position.z > maxBoundary.z)
        {
            direction.z = -direction.z;
        }
    }
}
