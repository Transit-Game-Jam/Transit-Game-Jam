using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TrainStation : MonoBehaviour
{
    [Header("Distance Data")]
    public PlayerController player;
    public float interactDistance = 5f;
    public Interactables interact;

    private Keyboard keyboard = Keyboard.current;

    void Awake()
    {
        player = FindAnyObjectByType<PlayerController>();
        interact = FindAnyObjectByType<Interactables>();
    }

    void Update()
    {
        GetDistance();
    }

    void GetDistance()
    {
        float distance = Vector2.Distance(player.transform.position, this.transform.position);

        if (distance < interactDistance)
        {
            interact.HandleTrainStationText();

            if (keyboard.spaceKey.wasPressedThisFrame)
            {
                SceneManager.LoadScene("TrainStation");
            }
        }
        else
        {
            interact.DisableText();
        }
    }
}
