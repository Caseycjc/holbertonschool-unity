using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab;
    public int numberOfTargets = 5;

    public void SpawnTargetsOnPlane(ARPlane plane)
    {
        List<Vector3> boundary = new List<Vector3>();
        if (TryGetBoundaryFromPlane(plane, ref boundary))
        {
            for (int i = 0; i < numberOfTargets; i++)
            {
                Vector3 position = GetRandomPositionWithinBoundary(boundary, plane.transform.position.y);
                Quaternion rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
                GameObject target = Instantiate(targetPrefab, position, rotation);
                target.transform.SetParent(plane.transform, true);

                TargetBehavior targetBehavior = target.GetComponent<TargetBehavior>();
                if (targetBehavior != null)
                {
                    targetBehavior.Initialize(plane);
                }
            }
        }
    }

    private bool TryGetBoundaryFromPlane(ARPlane plane, ref List<Vector3> boundary)
    {
        boundary.Clear();

        foreach (var point in plane.boundary)
        {
            Vector3 worldPoint = plane.transform.TransformPoint(point);
            boundary.Add(worldPoint);
        }

        return boundary.Count > 0;
    }

    private Vector3 GetRandomPositionWithinBoundary(List<Vector3> boundary, float groundHeight)
    {
        Vector2 randomPoint2D = GetRandomPointInBoundary(boundary);
        Vector3 randomPosition = new Vector3(randomPoint2D.x, groundHeight, randomPoint2D.y);

        return randomPosition;
    }

    private Vector2 GetRandomPointInBoundary(List<Vector3> boundary)
    {
        Vector3 randomPoint = boundary[Random.Range(0, boundary.Count)];
        return new Vector2(randomPoint.x, randomPoint.z);
    }
}
