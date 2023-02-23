using System.Collections;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    // Reference to the object pool
    public ObjectPool objectPool;

    // The minimum and maximum position at which platforms can spawn
    public float minSpawnPos;
    public float maxSpawnPos;

    private void Start()
    {
        // Start the coroutine to spawn platforms
        StartCoroutine(SpawnPlatforms());
    }

    private IEnumerator SpawnPlatforms()
    {
        // Infinite loop to continuously spawn platforms
        while (true)
        {
            // Wait for a random amount of time between 1 and 4 seconds
            yield return new WaitForSeconds(Random.Range(1, 4));
            // Get a platform from the object pool
            GameObject platform = objectPool.GetPlatform();
            // Set the platform's position to a random position between minSpawnPos and maxSpawnPos on the x-axis and the spawner's position on the y-axis
            platform.transform.position = new Vector2(Random.Range(minSpawnPos, maxSpawnPos), transform.position.y);
            // Activate the platform
            platform.SetActive(true);
        }
    }
}
/*
This script is responsible for spawning platforms in the game world. It uses an object pool to reuse platforms instead of creating and destroying them constantly.
The script first defines the object pool and the minimum and maximum positions at which the platforms can spawn. Then, in the Start() function, it starts a coroutine to continuously spawn platforms.
The SpawnPlatforms() coroutine has an infinite loop that waits for a random amount of time between 1 and 4 seconds and then gets a platform from the object pool. 
It sets the platform's position to a random position between minSpawnPos and maxSpawnPos on the x-axis and the spawner's position on the y-axis, and then activates the platform.
Overall, this script allows for efficient spawning of platforms in the game world using an object pool.
*/