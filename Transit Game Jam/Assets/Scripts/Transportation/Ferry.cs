using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Ferry : MonoBehaviour
{
    [Header("Movement")]
    public float ferrySpeed = 0.25f;
    public float ferryDistance = 1f;

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
        interact = FindAnyObjectByType<Interactables>();
        player = FindAnyObjectByType<PlayerController>();
    }

    void Update()
    {
        HandleMovement();
        GetDistance();
    }

    void HandleMovement()
    {
        float testFactor = Mathf.PingPong(Time.time * ferrySpeed, ferryDistance);
        this.transform.position = Vector2.Lerp(destination_1.position, destination_2.position, testFactor);
    }

    void GetDistance()
    {
        float distance = Vector2.Distance(player.transform.position, this.transform.position);

        if (distance < interactDistance)
        {
            interact.HandleFerryText();

            if (keyboard.spaceKey.wasPressedThisFrame)
            {
                SceneManager.LoadScene("FerryInterior");
            }
        }
        else
        {
            interact.DisableText();
        }
    }
}
