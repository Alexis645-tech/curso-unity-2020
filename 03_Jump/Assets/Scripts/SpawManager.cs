using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawManager : MonoBehaviour
{

    public GameObject[] obstacles;
    private Vector3 SpawnPos;
    private float startDelay = 2;
    private float repeatRate = 2;

    private PlayerController _playerController;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPos = this.transform.position;
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        _playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if (!_playerController.GameOver)
        {
            GameObject obstacle = obstacles[Random.Range(0, obstacles.Length)];
            Instantiate(obstacle, SpawnPos, obstacle.transform.rotation);
        }
    }
}
