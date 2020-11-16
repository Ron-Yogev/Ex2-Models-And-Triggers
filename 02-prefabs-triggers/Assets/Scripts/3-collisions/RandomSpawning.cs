using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This component spawning prefabs in selected radius,
 * in a selected time radius
 */
public class RandomSpawning : MonoBehaviour
{
    [Tooltip("prefab that you want to spawn")]
    [SerializeField] GameObject prefabToSpawn;
    [Tooltip("Minimum time between consecutive spawns, in seconds")] 
    [SerializeField] float minTimeBetweenSpawns = 8f;
    [Tooltip("Maximum time between consecutive spawns, in seconds")] 
    [SerializeField] float maxTimeBetweenSpawns = 12f;
    [Tooltip("Min and Max radius in x axis")] 
    [SerializeField] float MinMaxSpawnPosX = 8f;
    [Tooltip("Min and Max radius in y axis")] 
    [SerializeField] float MinMaxSpawnPosY = 5f;

    // Start is called before the first frame update
    void Start()
    {
       this.StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true) { 
            // random secaonds waiting till the next spawn
            float timeBetweenSpawns = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
            yield return new WaitForSeconds(timeBetweenSpawns);
            //random position to spawn the prefab
            Vector3 positionOfSpawnedObject = new Vector3(Random.Range(-MinMaxSpawnPosX, MinMaxSpawnPosX), Random.Range(-MinMaxSpawnPosY, MinMaxSpawnPosY), 0);
            GameObject newObject = Instantiate(prefabToSpawn.gameObject, positionOfSpawnedObject, Quaternion.identity);
        }
    }
}
