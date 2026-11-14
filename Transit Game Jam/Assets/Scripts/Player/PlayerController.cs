using UnityEngine;
using UnityEngine.InputSystem.iOS;

public class PlayerController : MonoBehaviour
{
    [Header("Walk")]
    [SerializeField] private float WalkSpeed = 3f;

    private Rigidbody2D playerRB;
    private PlayerInput playerInput;

    private Vector2 MoveInput;
    private State currentState;

    public enum State
    {
        Idle,
        Walk
    }

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
    }


    private void OnStateEnter()
    {
        switch (currentState)
        {
            case State.Walk:
                Debug.Log("Entered Walk State");
                break;
            case State.Idle:
                Debug.Log("Entered Idle State");
                break;
        }
    }

    private void Update()
    {
        UpdateState();
        MoveInput = playerInput.inputActions.Player.Move.ReadValue<Vector2>();
        playerRB.linearVelocity = MoveInput * WalkSpeed;
    }

    private void UpdateState()
    {
        switch(currentState)
        {
            case State.Walk:
                if (playerInput.inputActions.Player.Move.ReadValue<Vector2>() == Vector2.zero)
                {
                    currentState = State.Idle;
                    OnStateEnter();
                }
                break;
            case State.Idle:
                if (playerInput.inputActions.Player.Move.ReadValue<Vector2>() != Vector2.zero)
                {
                    currentState = State.Walk;
                    OnStateEnter();
                }
                break;
        }
    }
}
