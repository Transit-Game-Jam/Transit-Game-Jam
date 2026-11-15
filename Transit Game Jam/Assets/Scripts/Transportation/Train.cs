using JetBrains.Annotations;
using System.Collections;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Train : MonoBehaviour
{
    [Header("Movement")]
    public float trainSpeed = 5f;
    public float trainDistance = 5f;

    /*[Header("AI")]
    public NavMeshAgent agent;*/

    [Header("Travel Destination")]
    public Transform destination1;
    public Transform destination2;

    public Transform cacheStartPosition;
    public Vector2 currentDestination;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HandleMovingBehaviour();
    }

    void HandleMovingBehaviour()
    {
        this.transform.position = new Vector2(Mathf.PingPong(Time.time * trainSpeed, destination1.position.x * trainDistance) , 0);
    }
}
