using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawning : MonoBehaviour
{
    public GameObject shield;
    [Tooltip("Minimum time between consecutive spawns, in seconds")] [SerializeField] float minTimeBetweenSpawns = 4f;
    [Tooltip("Maximum time between consecutive spawns, in seconds")] [SerializeField] float maxTimeBetweenSpawns = 7f;
    [Tooltip("Minimum time between consecutive spawns, in seconds")] [SerializeField] float MinMaxSpawnPosX = 8f;
    [Tooltip("Minimum time between consecutive spawns, in seconds")] [SerializeField] float MinMaxSpawnPosY = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
        shield = GameObject.FindGameObjectWithTag("Shield");
        
        this.StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        
        while (true)
        {
            shield.SetActive(false);
            float timeBetweenSpawns = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
            yield return new WaitForSeconds(timeBetweenSpawns);
            this.transform.position = new Vector3(Random.Range(-MinMaxSpawnPosX, MinMaxSpawnPosX), Random.Range(-MinMaxSpawnPosY, MinMaxSpawnPosY), 0);
            shield.SetActive(true);

        }
    }
}
