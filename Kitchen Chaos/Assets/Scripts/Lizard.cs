using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;


public class Lizard : MonoBehaviour
{
    public Transform destinationMarker;

    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _agent.SetDestination(destinationMarker.position);
    }
}
