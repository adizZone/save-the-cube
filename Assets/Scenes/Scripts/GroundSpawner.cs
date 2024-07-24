using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundPrefab; // Reference to the ground platform prefab
    public int numberOfPlatforms; // Number of platforms to spawn initially
    public float platformLength = 10f; // Length of each platform
    private Vector3 nextSpawnPosition; // Position to spawn the next platform

    private Queue<GameObject> platformQueue = new Queue<GameObject>();

    void Start()
    {
        // Initialize the spawn position
        nextSpawnPosition = Vector3.zero;

        // Spawn initial platforms
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            SpawnPlatform();
        }
    }

    void Update()
    {
        // Check if the player is close to the end of the last platform
        if (transform.position.z >= nextSpawnPosition.z - (numberOfPlatforms * platformLength))
        {
            // Spawn new platform
            SpawnPlatform();

            // Remove the oldest platform to prevent infinite platform buildup
            GameObject oldPlatform = platformQueue.Dequeue();
            Destroy(oldPlatform);
        }
    }

    void SpawnPlatform()
    {
        // Instantiate a new platform at the next spawn position
        GameObject newPlatform = Instantiate(groundPrefab, nextSpawnPosition, Quaternion.identity);
        platformQueue.Enqueue(newPlatform);

        // Update the next spawn position
        nextSpawnPosition.z += platformLength;
    }
}
