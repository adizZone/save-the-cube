using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnDistance;
    public float playerPositionZOffset; // Distance ahead of player to spawn obstacles
    private Vector3 lastSpawnPosition;

    void Start()
    {
        // Initialize the first spawn position
        lastSpawnPosition = transform.position;
    }

    void Update()
    {
        // Check if the player has moved far enough to spawn the next set of obstacles
        if (transform.position.z - lastSpawnPosition.z > spawnDistance)
        {
            SpawnObstacles();
        }
    }

    void SpawnObstacles()
    {
        // Calculate the new spawn position based on player position and offset
        Vector3 spawnPosition = new Vector3(0, 0, transform.position.z + playerPositionZOffset);

        // Instantiate the obstacle set at the new position
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

        // Update the last spawn position
        lastSpawnPosition = spawnPosition;
    }
}
