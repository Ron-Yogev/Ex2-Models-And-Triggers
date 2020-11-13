using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawning : MonoBehaviour
{
    public GameObject shield;
    [Tooltip("Minimum time between consecutive spawns, in seconds")] [SerializeField] float minTimeBetweenSpawns = 1f;
    [Tooltip("Maximum time between consecutive spawns, in seconds")] [SerializeField] float maxTimeBetweenSpawns = 3f;
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
        shield.SetActive(false);

        while (true)
        {
            float timeBetweenSpawns = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
            yield return new WaitForSeconds(timeBetweenSpawns);
            this.transform.position = new Vector3(Random.Range(-MinMaxSpawnPosX, MinMaxSpawnPosX), Random.Range(-MinMaxSpawnPosY, MinMaxSpawnPosY), 0);
            //this.enabled = true;
            //GameObject newObject = Instantiate(this.gameObject, new_pos, Quaternion.identity);
        }
    }
}
