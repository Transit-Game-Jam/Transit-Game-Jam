using Unity.VisualScripting;
using UnityEngine;

public class Pedestrians : MonoBehaviour
{

    [SerializeField] private float pedSpeed = 2f;
    //[SerializeField] private float pedestrianDistance = 2f;

    [Header("Travel Destination")]
    public Transform waypoint1;
    //public Transform waypoint2;

    private void Start()
    {
        PedestrianWaypoint();
        //PedestrianMovement();
    }

    void PedestrianWaypoint()
    {
        Transform target = waypoint1;
        transform.position = Vector2.MoveTowards(transform.position, target.position, pedSpeed * Time.deltaTime);
    }


    void PedestrianMovement()
    {
        //this.transform.position = new Vector2(Mathf.PingPong(Time.time * pedSpeed, waypoint1.position.x * pedestrianDistance), 0);
    }

}
