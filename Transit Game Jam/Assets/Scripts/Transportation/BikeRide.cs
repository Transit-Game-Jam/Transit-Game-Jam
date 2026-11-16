using UnityEngine;
using UnityEngine.InputSystem;

public class BikeRide : MonoBehaviour
{
    public float bikeSpeed = 5f;

    private Rigidbody2D rb;

    public BikeInput bikeInput;


    private Vector2 bikeMove;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        enabled = false;
    }

    private void OnEnable()
    {
        bikeInput.Enable();
    }

    private void OnDisable()
    {
        bikeInput.Disable();
    }

    void Update()
    {
        bikeMove = bikeInput.BikeRide.Move.ReadValue<Vector2>();
        rb.angularVelocity = -bikeMove.x * bikeSpeed * 100f;
    }
}
