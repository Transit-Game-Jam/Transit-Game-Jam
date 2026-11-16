using UnityEngine;

public class Bike : MonoBehaviour
{
    [Header("Bike")]
    [SerializeField] private float Bikespeed = 15f;

    [Header("Input")]
    public InputActions inputActions;

    private Rigidbody2D bikeRB;

    private Vector2 MoveInput;


    private void Awake()
    {
        bikeRB = GetComponent<Rigidbody2D>();
        inputActions = new InputActions();
    }

    public void OnEnable()
    {
        inputActions.Enable();
    }

    public void OnDisable()
    {
        inputActions.Disable();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            MoveInput = inputActions.Player.Move.ReadValue<Vector2>();
            bikeRB.angularVelocity = -MoveInput.x * Bikespeed;
        }
        else if(collision.collider.CompareTag("Obstacle"))
        {
            OnDisable();
        }
    }




}
