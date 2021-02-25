using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdSpawn : MonoBehaviour
{
    //Implamented from learning from these tutorials: https://www.youtube.com/watch?v=ydjpNNA5804 https://learn.unity.com/tutorial/instantiate#5c8a6a09edbc2a001f47d7cf
    public GameObject prisoner;

    public int spawnedObjects;
    public int spawnLimit;

    Vector3 spawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        spawnLimit = Random.Range(12, 18);
        
        StartCoroutine(Spawn());


    }

    Vector3 Spawner()
    {
            int x_position = Random.Range(-14, 8);
            int z_position = Random.Range(-11, 8);
            Vector3 spawnPosition = new Vector3(x_position, 1, z_position);
            return spawnPosition;
    }
    IEnumerator Spawn()
    {
        while (spawnedObjects < spawnLimit)
        {
            Instantiate(prisoner, Spawner(), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            spawnedObjects += 1;

        }
    }
}