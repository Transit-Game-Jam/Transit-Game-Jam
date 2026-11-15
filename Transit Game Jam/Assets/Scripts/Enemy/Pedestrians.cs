using Unity.VisualScripting;
using UnityEngine;

public class Pedestrians : MonoBehaviour
{

    [SerializeField] private float pedSpeed = 2f;
    //[SerializeField] private float pedestrianDistance = 2f;

    [Header("Travel Destination")]
    public Transform waypoint1;
    public Transform waypoint2;


    private Transform currentTarget;


    private void Start()
    {

        currentTarget = waypoint1;
        PedestrianWaypoint();
        //PedestrianMovement();
    }

    private void Update()
    {
        PedestrianWaypoint();
        if (Vector2.Distance(transform.position, currentTarget.position) < 0.1f)
        {
            currentTarget = currentTarget == waypoint1 ? waypoint2 : waypoint1;
        }

    }

    void PedestrianWaypoint()
    {
        Transform target = currentTarget;
        transform.position = Vector2.MoveTowards(transform.position, target.position, pedSpeed * Time.deltaTime);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Handle collision with the player
            Debug.Log("Pedestrian collided with the player!");
        }
    }

}
