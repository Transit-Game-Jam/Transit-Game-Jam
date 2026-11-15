using JetBrains.Annotations;
using System.Collections;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class Train : MonoBehaviour
{
    [Header("Movement")]
    public float trainSpeed = 5f;
    public float trainDistance = 5f;

    [Header("Travel Destination")]
    public Transform destination_1;
    public Transform destination_2;

    [Header("Distance Data")]
    public PlayerController player;
    public GameObject door;
    public float interactDistance = 5f;

    void Awake()
    {
        player = FindAnyObjectByType<PlayerController>();
    }

    void Update()
    {
        HandleMovement();
        GetDistance();
    }

    void HandleMovement()
    {
        float testFactor = Mathf.PingPong(Time.time * trainSpeed, trainDistance);
        this.transform.position = Vector2.Lerp(destination_1.position, destination_2.position, testFactor);
    }

    void GetDistance()
    {
        float distance = Vector2.Distance(player.transform.position, door.transform.position);

        if (distance < interactDistance)
        {
            
        }
    }

}
