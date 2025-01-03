using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [Header("Waypoint status")]
    public WayPoint previousWaypoint;
    public WayPoint nextWaypoint;

    [Range(0f, 5f)]
    public float wayPointWidth = 1f;
    public Vector3 GetPosition()
    {
        Vector3 minBound = transform.position + transform.right * wayPointWidth / 2f;
        Vector3 maxBound = transform.position - transform.forward * wayPointWidth / 2f;
        return Vector3.Lerp(minBound, maxBound, Random.Range(0f, 1f));
    }
}
