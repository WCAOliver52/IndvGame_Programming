using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    //Implamented from learning from these tutorials: https://www.youtube.com/watch?v=ydjpNNA5804 https://learn.unity.com/tutorial/instantiate#5c8a6a09edbc2a001f47d7cf
    public GameObject enemy;
    
    public int spawnedObjects;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());

    }

    Vector3 SpawnLoc()
    {
        int x_position = Random.Range(-33, 28);
        int z_position = Random.Range(-33, -41);
        Vector3 spawnPosition = new Vector3(x_position, 1, z_position);
        return spawnPosition;
    }

    IEnumerator Spawn()
    {
        while (spawnedObjects < 5)
        {
            Instantiate(enemy, SpawnLoc(), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            spawnedObjects += 1;

        }
    }

}
