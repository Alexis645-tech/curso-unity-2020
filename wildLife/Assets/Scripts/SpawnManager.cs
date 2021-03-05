using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    private int animalIndex;

    private float spawnRangeX = 15f;
    private float spawnPosZ;

    [SerializeField, Range(2, 5)]
    private float startDelay = 2f;
    [SerializeField, Range(0.1f, 3f)]
    private float spawnInterval = 1.5f;
    
    private void Start()
    {
        spawnPosZ = this.transform.position.z;
        InvokeRepeating("SpawnRandonAnimal", 
            startDelay, spawnInterval);
    }
    

    private void SpawnRandonAnimal()
    {
        float xRand = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPos = new Vector3(xRand, 0, spawnPosZ);

        animalIndex = Random.Range(0, enemies.Length);
        Instantiate(enemies[animalIndex],
            spawnPos,
            enemies[animalIndex].transform.rotation);
    }
    
}
