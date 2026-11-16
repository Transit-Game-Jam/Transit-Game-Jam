using UnityEngine;

public class Cars : MonoBehaviour
{

    [SerializeField] private float CarSpeed = 20f;
    public Transform WaypointParent;

    private Transform[] waypoints;

    private int currentWaypointIndex;

    public bool loopWaypoints = true; // Set to true if you want the car to loop through waypoints

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
        MoveTowardsWaypoint();
    }

    void MoveTowardsWaypoint()
    {
        Transform target = waypoints[currentWaypointIndex];

        transform.position = Vector2.MoveTowards(transform.position, target.position, CarSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            int nextWaypointIndex;

            do
            {
                nextWaypointIndex = Random.Range(0, waypoints.Length);
            }
            while (nextWaypointIndex == currentWaypointIndex);

            currentWaypointIndex = nextWaypointIndex;
        }
    }
}
