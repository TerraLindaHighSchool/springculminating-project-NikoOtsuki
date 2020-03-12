using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclesPrefabs;
    private float spawnRangeX = -10;
    private float spawnPosZ = 9;
    private float startDelay = 0.5f;
    private float spawnInterval = 1.0f;
    Transform[] spawnpoints;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomObstacle", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {


    }
    void SpawnRandomObstacle()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        int obstacleIndex = Random.Range(0, obstaclesPrefabs.Length);
        Instantiate(obstaclesPrefabs[obstacleIndex], spawnPos, obstaclesPrefabs[obstacleIndex].transform.rotation);
    }
}
