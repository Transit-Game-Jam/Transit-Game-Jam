using UnityEngine;
using UnityEngine.InputSystem.iOS;

public class PlayerController : MonoBehaviour
{
    [Header("Walk")]
    [SerializeField] private float WalkSpeed = 3f;

    [Header("Input")]
    public InputActions inputActions;

    private Rigidbody2D playerRB;

    private Vector2 MoveInput;
    private State currentState;

    public enum State
    {
        Idle,
        Walk,
        Swim
    }

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        inputActions = new InputActions();
    }

    private void OnEnable()
    {
        inputActions.Enable();
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
        MoveInput = inputActions.Player.Move.ReadValue<Vector2>();
        playerRB.linearVelocity = MoveInput * WalkSpeed;
    }

    private void UpdateState()
    {
        switch(currentState)
        {
            case State.Walk:
                if (MoveInput == Vector2.zero)
                {
                    currentState = State.Idle;
                    OnStateEnter();
                }
                break;

            case State.Idle:
                if (MoveInput != Vector2.zero)
                {
                    currentState = State.Walk;
                    OnStateEnter();
                }
                break;
        }
    }
}
