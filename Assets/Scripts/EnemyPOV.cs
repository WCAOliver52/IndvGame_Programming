using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPOV : MonoBehaviour
{
    //Implamented from learning from these tutorials: https://learn.unity.com/project/john-lemon-s-haunted-jaunt-3d-beginner?uv=2019.4
    public Transform player;
    public GameEnding gameEnding;

    bool playerInRange;

     void Update()
    {
        if (playerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            playerInRange = false;
        }
    }

   
}
