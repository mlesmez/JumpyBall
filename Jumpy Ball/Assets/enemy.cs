using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public GameObject targetPoint;
    public NavMeshAgent myAgent;

    private void Start()
    {
        targetPoint = GameObject.FindGameObjectWithTag("Player");
        myAgent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (targetPoint != null)
        {
            myAgent.SetDestination(targetPoint.transform.position);
        }
    }
}
