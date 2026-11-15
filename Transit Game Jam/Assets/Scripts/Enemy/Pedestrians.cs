using Unity.VisualScripting;
using UnityEngine;

public class Pedestrians : MonoBehaviour
{

    [SerializeField] private float pedSpeed = 2f;
    [SerializeField] private float pedestrianDistance = 2f;

    [Header("Travel Destination")]
    public Transform waypoint1;
    /// <summary>
    /// The second waypoint for the pedestrian to travel to.
    /// </summary>
   // public Transform waypoint2;

    private void Start()
    {
        PedestrianMovement();
    }


    void PedestrianMovement()
    {
        this.transform.position = new Vector2(Mathf.PingPong(Time.time * pedSpeed, waypoint1.position.x * pedestrianDistance), 0);
    }

}
