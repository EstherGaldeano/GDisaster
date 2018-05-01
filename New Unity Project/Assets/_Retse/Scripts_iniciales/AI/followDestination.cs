using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class followDestination : MonoBehaviour
{

    private NavMeshAgent theAgent = null;
    public Transform destination = null;


    void Awake()
    {
        theAgent = GetComponent<NavMeshAgent>();
        

    }

    void Update()
    {

        theAgent.SetDestination(destination.position);
    }
}