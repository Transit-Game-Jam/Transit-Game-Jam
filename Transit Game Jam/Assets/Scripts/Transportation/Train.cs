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

    /*[Header("AI")]
    public NavMeshAgent agent;*/

    [Header("Travel Destination")]
    public Transform destination1;
    public Transform destination2;

    public Transform cacheStartPosition;
    public Vector2 currentDestination;

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

    }

    // Update is called once per frame
    void Update()
    {
        //HandleStateTransitions();
        HandleStateBehavior();
    }

    #region Transition Behaviour

    void HandleStateTransitions()
    {
        if (this.transform.position == destination1.position)
        {
            currentDestination = destination2.position;
            currentState = TrainStates.Moving;
        }

        /*if (this.transform.position == destination2.position)
        {
            currentDestination = destination1.position;
            currentState = TrainStates.Moving;
        }*/
    }

    #endregion

    #region State Behaviour

    void HandleStateBehavior()
    {
        switch (currentState)
        {
            /*case TrainStates.Stopped:
                HandleStoppedBehaviour();
                break;*/

            default:
                HandleMovingBehaviour();
                break;
        }
    }

    /*void HandleStoppedBehaviour()
    {
        agent.speed = 0f;
        agent.destination = this.transform.position;
    }*/

    void HandleMovingBehaviour()
    {
        /*agent.speed = 5f;
        agent.destination = currentDestination;*/

        this.transform.position = new Vector2(Mathf.PingPong(destination1.position.x, destination2.position.x) * Time.deltaTime, 0);
    }
    #endregion
}
