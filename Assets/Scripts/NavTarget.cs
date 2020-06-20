using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavTarget : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent navMeshAgent;

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(target.position);
    }
}
