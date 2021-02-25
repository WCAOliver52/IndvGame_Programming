using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimplePath: MonoBehaviour
{
    //Implamented from learning from these tutorials: https://learn.unity.com/project/john-lemon-s-haunted-jaunt-3d-beginner?uv=2019.4
    public NavMeshAgent enemyAgent;
    public Transform[] waypoints;

    int currentWaypoint;

    // Start is called before the first frame update
    void Start()
    {
        enemyAgent.SetDestination(waypoints[0].position);

    }

    // Update is called once per frame
    void Update()
    {
        if (enemyAgent.remainingDistance < enemyAgent.stoppingDistance)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;

            enemyAgent.SetDestination(waypoints[currentWaypoint].position);
        }
    }
}