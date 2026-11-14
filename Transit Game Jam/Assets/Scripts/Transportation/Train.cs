using JetBrains.Annotations;
using System.Collections;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;

public class Train : MonoBehaviour
{
    [Header("Movement")]
    public float trainSpeed = 5f;

    [Header("Travel Destination")]
    public Transform destination1;
    public Transform destination2;
    public Transform currentDestination;

    [Header("States")]
    public TrainStates currentState;
    public float transitionTime;

    public enum TrainStates
    {
        Stopped,
        Moving
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentDestination = destination1;
    }

    // Update is called once per frame
    void Update()
    {
        HandleDestination();
        HandleStateTransitions();
        HandleStateBehavior();

    }

    #region Destination Behaviour

    void HandleDestination()
    {
        if (transform.position == destination1.position)
        {
            currentDestination.position = destination2.position;
        }

        if (transform.position == destination2.position)
        {
            currentDestination.position = destination1.position;
        }
    }
    
    #endregion

    #region Transition Behaviour

    void HandleStateTransitions()
    {
        float transitionTimer = 0f;

        if (transform.position == currentDestination.position)
        {
            transitionTimer = 0f;
            currentState = TrainStates.Stopped;
            transitionTimer += Time.deltaTime;
        }

        if (transitionTimer > 5f)
        {
            currentState = TrainStates.Moving;
        }
    }

    #endregion

    #region State Behaviour

    void HandleStateBehavior()
    {
        switch (currentState)
        {
            case TrainStates.Stopped:
                HandleStoppedBehaviour();
                break;

            case TrainStates.Moving:
                HandleMovingBehaviour();
                break;
        }
    }

    void HandleStoppedBehaviour()
    {
        trainSpeed = 0f;
        transform.position = Vector2.Lerp(transform.position, transform.position, Time.deltaTime);
    }

    void HandleMovingBehaviour()
    {
        trainSpeed = 2f;
        transform.position = Vector2.Lerp(transform.position, currentDestination.position, Time.deltaTime);
    }
    #endregion
}
