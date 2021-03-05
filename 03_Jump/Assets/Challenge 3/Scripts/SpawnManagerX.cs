using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    private Vector3 spawnPos;
    private float spawnDelay = 2;
    private float spawnInterval = 2;

    private PlayerControllerX playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        spawnPos = this.transform.position;
        InvokeRepeating("SpawnObjects", spawnDelay, spawnInterval);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
    }

    // Spawn obstacles
    void SpawnObjects ()
    {
        // Set random spawn location and random object index
        Vector3 spawnLocation = new Vector3(30, Random.Range(5, 15), 0);
        int index = Random.Range(0, objectPrefabs.Length);

        // If game is still active, spawn new object
        if (!playerControllerScript.gameOver)
        {
            GameObject obstacle = objectPrefabs[Random.Range(0, objectPrefabs.Length)];
            Instantiate(obstacle, spawnPos, obstacle.transform.rotation);
        }

    }
}
