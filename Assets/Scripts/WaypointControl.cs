using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

class WaypointControl : MonoBehaviour {
    public Transform[] waypoints;
    private NavMeshAgent _navMeshAgent;
    private int _currentIndex;

    private void Start() {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _currentIndex = 0;
        _navMeshAgent.SetDestination(waypoints[0].position);
    }

    private void Update(){
        if(_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance){
            _currentIndex++;
            if ( _currentIndex == waypoints.length ){
                _currentIndex = 0;
            }
        _navMeshAgent.SetDestination(waypoints[_currentIndex].position);
        }
    }
}