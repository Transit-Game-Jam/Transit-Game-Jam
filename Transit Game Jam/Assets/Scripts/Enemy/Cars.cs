using UnityEngine;

public class Cars : MonoBehaviour
{

    [SerializeField] private float CarSpeed = 3f;
    [SerializeField] private Transform WaypointParent;

    private Transform[] waypoints;

    private int currentWaypointIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        waypoints = new Transform[WaypointParent.childCount];

        for (int i = 0; i < WaypointParent.childCount; i++)
        {
            waypoints[i] = WaypointParent.GetChild(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //MoveTowardsWaypoint();
    }

    void MoveTowardsWaypoint()
    {
        Transform target = waypoints[currentWaypointIndex];

        transform.position = Vector2.MoveTowards(transform.position, target.position, CarSpeed * Time.deltaTime);
    }
}
