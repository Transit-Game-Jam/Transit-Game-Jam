using System.Collections;
using UnityEngine;

public class BiggerRats : MonoBehaviour
{

    [SerializeField] private float fatRatSpeed = 3f;


    [Header("Travel Destination")]
    public Transform waypoint1;
    public Transform waypoint2;

    private Transform currentTarget;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentTarget = waypoint1;
        FatRatWaypoint();
    }

    // Update is called once per frame
    void Update()
    {
        FatRatWaypoint();
        if (Vector2.Distance(transform.position, currentTarget.position) < 0.1f)
        {
            currentTarget = currentTarget == waypoint1 ? waypoint2 : waypoint1;
        }
    }


    void FatRatWaypoint()
    {
        Transform target = currentTarget;
        transform.position = Vector2.MoveTowards(transform.position, target.position, fatRatSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Handle collision with the player
            StartCoroutine(FatRatSpeedUp());
            Debug.Log("Fat Rat collided with the player!");
        }
    }

    private IEnumerator FatRatSpeedUp()
    {
        fatRatSpeed *= 3f; // Double the speed
        yield return new WaitForSeconds(2f); // Wait for 2 seconds
        fatRatSpeed /= 3f; // Reset the speed back to normal
    }
}
