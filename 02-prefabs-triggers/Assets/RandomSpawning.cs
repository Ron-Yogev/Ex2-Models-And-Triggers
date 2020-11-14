using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawning : MonoBehaviour
{
    [SerializeField] GameObject prefabToSpawn;
    [Tooltip("Minimum time between consecutive spawns, in seconds")] [SerializeField] float minTimeBetweenSpawns = 8f;
    [Tooltip("Maximum time between consecutive spawns, in seconds")] [SerializeField] float maxTimeBetweenSpawns = 12f;
    [Tooltip("Minimum time between consecutive spawns, in seconds")] [SerializeField] float MinMaxSpawnPosX = 8f;
    [Tooltip("Minimum time between consecutive spawns, in seconds")] [SerializeField] float MinMaxSpawnPosY = 5f;

    // Start is called before the first frame update
    void Start()
    {
       this.StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true) { 
            float timeBetweenSpawns = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
            yield return new WaitForSeconds(timeBetweenSpawns);
            Vector3 positionOfSpawnedObject = new Vector3(Random.Range(-MinMaxSpawnPosX, MinMaxSpawnPosX), Random.Range(-MinMaxSpawnPosY, MinMaxSpawnPosY), 0);
            GameObject newObject = Instantiate(prefabToSpawn.gameObject, positionOfSpawnedObject, Quaternion.identity);
        }
    }
}
