using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CrowdPath : MonoBehaviour
{
    //Implamented from learning from these tutorials: https://learn.unity.com/project/john-lemon-s-haunted-jaunt-3d-beginner?uv=2019.4
    public NavMeshAgent crowdAgent;
    public Transform[] waypoints;

    int currentWaypoint;

    // Start is called before the first frame update
    void Start()
    {
        crowdAgent.SetDestination(waypoints[0].position);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (crowdAgent.remainingDistance < crowdAgent.stoppingDistance)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;

            crowdAgent.SetDestination(waypoints[currentWaypoint].position);
        }
        
    }
}
