using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Bus : MonoBehaviour
{
    [Header("Movement")]
    public float busSpeed = 0.25f;
    public float busDistance = 1f;

    [Header("Travel Destination")]
    public Transform destination_1;
    public Transform destination_2;

    [Header("Distance Data")]
    public PlayerController player;
    public float interactDistance = 5f;
    public Interactables interact;

    private Keyboard keyboard = Keyboard.current;

    void Awake()
    {
        try
        {
            player = FindAnyObjectByType<PlayerController>();
            interact = FindAnyObjectByType<Interactables>();
        }
        catch (NullReferenceException error)
        {
            Debug.Log($"Error: {error}, Cannot cache references to these object(s), please add an instance of them in this scene");
        }
    }

    void Update()
    {
        HandleMovement();
        GetDistance();
    }

    void HandleMovement()
    {
        float testFactor = Mathf.PingPong(Time.time * busSpeed, busDistance);
        this.transform.position = Vector2.Lerp(destination_1.position, destination_2.position, testFactor);
    }

    void GetDistance()
    {
        float distance = Vector2.Distance(player.transform.position, this.transform.position);

        if (distance < interactDistance)
        {
            interact.HandleBusText();

            if (keyboard.spaceKey.wasPressedThisFrame)
            {
                SceneManager.LoadScene("BusInterior");
            }
        }
        else
        {
            interact.DisableText();
        }
    }
}
