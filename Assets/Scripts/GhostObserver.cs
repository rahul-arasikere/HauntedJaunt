using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostObserver : MonoBehaviour
{
    public GameEnding gameEnding;
    public Transform player;
    public NavMeshAgent navMeshAgent;
    private bool _isPlayerInRange;


    private void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            _isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            _isPlayerInRange = false;
        }
    }

    private void Update()
    {
        if (GameState.Instance._isDetected)
        {
            navMeshAgent.SetDestination(player.position);
        }
        if (_isPlayerInRange)
        {
            Vector3 direction = player.position - transform.position;
            direction.y += 0.25f;
            Ray ray = new Ray(origin: transform.position, direction);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.transform == player)
                {
                    GameState.Instance.PlayerDetected();
                    if (hit.distance < 0.5f)
                    {
                        gameEnding.CaughtPlayer();
                    }
                    else
                    {
                        navMeshAgent.SetDestination(player.position);
                    }
                }
            }
        }
    }
}
