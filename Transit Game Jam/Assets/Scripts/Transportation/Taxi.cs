using UnityEngine;

public class Taxi : MonoBehaviour
{
    [SerializeField] private float TaxiSpeed = 20f;
    public Transform TaxiWaypointParent;
    public float interactDistance = 5f;

    private Transform[] waypoints;

    private int currentWaypointIndex;

    public Interactables interact;

    public PlayerController player;

    public bool loopWaypoints = true; // Set to true if you want the car to loop through waypoints

    private void Awake()
    {
        interact = FindAnyObjectByType<Interactables>();
        player = FindAnyObjectByType<PlayerController>();
    }
    void Start()
    {
        waypoints = new Transform[TaxiWaypointParent.childCount];

        for (int i = 0; i < TaxiWaypointParent.childCount; i++)
        {
            waypoints[i] = TaxiWaypointParent.GetChild(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsWaypoint();
        GetDistance();
    }

    void MoveTowardsWaypoint()
    {
        Transform target = waypoints[currentWaypointIndex];

        transform.position = Vector2.MoveTowards(transform.position, target.position, TaxiSpeed * Time.deltaTime);


        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            currentWaypointIndex++;

            if (currentWaypointIndex >= waypoints.Length)
            {
                if (loopWaypoints)
                {
                    currentWaypointIndex = 0;
                }
                else
                {
                    currentWaypointIndex = waypoints.Length - 1;
                }
            }
        }
        /*if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            int nextWaypointIndex;

            do
            {
                nextWaypointIndex = Random.Range(0, waypoints.Length);
            }
            while (nextWaypointIndex == currentWaypointIndex);

            currentWaypointIndex = nextWaypointIndex;
        }*/
    }

    void GetDistance()
    {
        float distance = Vector2.Distance(player.transform.position, this.transform.position);
        if (distance < interactDistance)
        {
            interact.HandleTaxiText();
        }
        else
        {
            interact.DisableText();
        }
    }
}
