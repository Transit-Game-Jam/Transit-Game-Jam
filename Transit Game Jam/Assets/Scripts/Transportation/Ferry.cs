using UnityEngine;

public class Ferry : MonoBehaviour
{
    [Header("Movement")]
    public float ferrySpeed = 0.25f;
    public float ferryDistance = 1f;

    [Header("Travel Destination")]
    public Transform destination_1;
    public Transform destination_2;

    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        float testFactor = Mathf.PingPong(Time.time * ferrySpeed, ferryDistance);
        this.transform.position = Vector2.Lerp(destination_1.position, destination_2.position, testFactor);
    }
}
