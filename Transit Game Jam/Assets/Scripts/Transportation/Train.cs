using JetBrains.Annotations;
using UnityEngine;

public class Train : MonoBehaviour
{
    [Header("Movement")]
    public Rigidbody2D rb;
    public float trainSpeed = 5f;

    [Header("Travel Destination")]
    public Transform destination1;
    public Transform destination2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTrain();   
    }

    void MoveTrain()
    {
        transform.position = Vector2.Lerp(destination1.position, destination2.position, trainSpeed);
    }

}
